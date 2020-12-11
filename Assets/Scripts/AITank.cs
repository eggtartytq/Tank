using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITank : Unit
{
    public float enemySearchRange;      //搜索半径
    public float moveSpeed;
    public ISRange attackRange;   //攻击半径
    public ISRange stoppingDistance;
    public float AICoreTimer; //  冷却时间
    public float rotateSpeed;   //敌人旋转速度
    
    //public GameObject completeWINObjectUI;
    

    private GameObject enemy;   //玩家

    //private float timer;
    private TankWeapon tw;
    private NavMeshAgent nam;
    private LayerMask enemyLayer;
    private float curAR;    //当前攻击范围
    private float curSD;    //当前停止距离
    void Start()
    {
        enemyLayer = LayerManager.GetEnemyLayer(team);
        tw = GetComponent<TankWeapon>();
        nam = GetComponent<NavMeshAgent>();
        nam.updateRotation = true;
        nam.updatePosition = true;
        tw.Init(team);
        StartCoroutine(Timer());
        Debug.Log(Timer());
    }

     void Update()
    {
        //nam.SetDestination(player.transform.position);
       // timer += Time.fixedDeltaTime;
        if (enemy == null)
        {
            SearchEnemy();
            return;
        }
        float dist = Vector3.Distance(enemy.transform.position, transform.position);

        

        if (dist > curAR)
        {
            nam.SetDestination(enemy.transform.position);
        }
        else
        {
            //nam.SetDestination(enemy.transform.position);
            
            nam.ResetPath();
            Vector3 dir = enemy.transform.position - transform.position;
            Quaternion wantedToRoatation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedToRoatation, rotateSpeed * Time.deltaTime);

            tw.Shoot();
            SearchEnemy();
            //transform.LookAt(player.transform.position);
            //if (timer > shootCoolDown)
            // {
            // tw.Shoot();
            //timer = 0f;
            // }
        }
        if (dist < curAR)
        {
            tw.Shoot();
        }
        Debug.Log(curAR);
        Debug.Log(curSD);

        
    }
    IEnumerator Timer()
    {
        while(true)
        {
            curAR = ISMath.Random(attackRange);
            curSD = ISMath.Random(stoppingDistance);
            curSD = Mathf.Min(curAR, curSD);
            yield return new WaitForSeconds(AICoreTimer);
        }
    }
    //在多个敌人中选取距离最近的
    public void SearchEnemy()
    {
        
        Collider[] cols = Physics.OverlapSphere(transform.position, enemySearchRange, enemyLayer);
        if (cols.Length > 0)
        {
            //enemy = cols[Random.Range(0, cols.Length)].gameObject;
            float curMinDistance = Mathf.Infinity;
            for(int i = 0; i < cols.Length; i++)
            {
                float curDist = Vector3.Distance(transform.position, cols[i].transform.position);
                if(curDist < curMinDistance)
                {
                    curMinDistance = curDist;
                    enemy = cols[i].gameObject;
                }
            }
        }
    }

    /*public void OnDestroy()
    {
        if (i == 2)
        {
            completeWINObjectUI.SetActive(true);
            Time.timeScale = 0;
            FCAudio.Stop();
        }
    }
    */
}
