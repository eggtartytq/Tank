using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public int damage;          //爆炸伤害
    public GameObject explosionEffect;  //爆炸效果
    public float explosionTimeUp;       //弹壳消失
    public float explosionRadius;       //爆炸半径
    public float explosionForce;        //爆炸威力

    private LayerMask lm;

    public void Init(LayerMask enemyLayer)
    {
        lm = enemyLayer;
    }
    void OnCollisionEnter()
    {
        GameObject shellExplosion = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
        Destroy(gameObject);
        Destroy(shellExplosion, explosionTimeUp);

        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadius, lm);
        if(cols.Length > 0)
        {
            for(int i = 0; i < cols.Length; i++)
            {
                Rigidbody r = cols[i].GetComponent<Rigidbody>();
                if (r != null)
                {
                    r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
                Unit u = cols[i].GetComponent<Unit>();
                if(u != null)
                {
                    u.ApplyDamage(damage);
                }
            }
        }
    }
}
