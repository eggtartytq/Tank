using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    public GameObject shell;            //弹药
    public float shootPower;            //弹药初速度
    public Transform shootPoint;    //弹药发射点
    public float shootCoolDown;

    private AudioSource shootFiring;        //开火声音
    //private Team hostTeam;
    private LayerMask enemyLayer;
    private bool isWeaponReady = true;

     void Start()
    {
        shootFiring = GetComponent<AudioSource>();
    }

    public void Init(Team team)
    {
        //hostTeam = team;
        enemyLayer = LayerManager.GetEnemyLayer(team);
    }

    public void Shoot()
    {
        if (!isWeaponReady) return;
        GameObject newShell = Instantiate(shell, shootPoint.position, shootPoint.rotation) as GameObject;
        newShell.GetComponent<Shell>().Init(enemyLayer);
        Rigidbody r = newShell.GetComponent<Rigidbody>();
        r.velocity = shootPoint.forward * shootPower;
        shootFiring.Play();
        isWeaponReady = false;
        StartCoroutine(WeaponCooldown());
    }

    IEnumerator WeaponCooldown()
    {
        yield return new WaitForSeconds(shootCoolDown);
        isWeaponReady = true;
    }
}
