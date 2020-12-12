using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tank : Unit
{

    public float moveSpeed;         //移动速度  7
    public float rotateSpeed;       //旋转速度  150
    public GameObject completeLoseObjectUI;
    public GameObject completeWinObjectUI;
    public AudioSource FCAudio;
    public Text HP;
    //private bool isGameOver = false;
    
    private TankWeapon tw;
    //private LayerMask enemyMask;
    private int enemyCount;
    void Start()
    {
        //enemyMask = LayerManager.GetEnemyLayer(team);
        tw = GetComponent<TankWeapon>();
        tw.Init(team); 
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * vertical);
        transform.Translate(Vector3.up * rotateSpeed * Time.deltaTime * horizontal);
        */

        //前后移动
        if (Input.GetKey(KeyCode.W))
        {
            //Time.deltaTime为上一帧所执行的时间，用于平衡速度
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime);         //向前
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, 1) * -moveSpeed * Time.deltaTime);    //向后
        }

        //左右旋转
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(new Vector3(0, 1, 0) * -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotateSpeed * Time.deltaTime);
        }

        //开火
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tw.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            health += 100;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("gameMap");
        }

       enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount <= 0) Win();
        HP.text = "HP: " + health;
    }

    public void OnDestroy()
    {
        //isGameOver = true;
        Lose();
        //Time.timeScale = 0;
        //FCAudio.Stop();
        //completeLoseObjectUI.SetActive(true);
        
    }
    

    public void Lose()
    {
        if (null == this)
        {
            Time.timeScale = 0;
            FCAudio.Stop();
            completeLoseObjectUI.SetActive(true);
        }

        Time.timeScale = 0;
        FCAudio.Stop();
        completeLoseObjectUI.SetActive(true);

    }
    public void Win()
    {
        if (null == this)
        {
            Time.timeScale = 0;
            FCAudio.Stop();
            completeWinObjectUI.SetActive(true);
        }
        Time.timeScale = 0;
        FCAudio.Stop();
        completeWinObjectUI.SetActive(true);
    }
    }
    


