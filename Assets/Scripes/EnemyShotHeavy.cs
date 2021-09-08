using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotHeavy : MonoBehaviour,IEnemyShot
{
    public GameObject ShellPrefabs;
    public Transform ShotPointPosion1;
    public Transform ShotPointPosion2;
    public float ShellPower = 30;
    public Animator anim;

    public void Shoot()
    {
        anim.SetTrigger("Fire");
        GameObject NewShell1 = Instantiate(ShellPrefabs, ShotPointPosion1.position, ShotPointPosion1.rotation);
        GameObject NewShell2 = Instantiate(ShellPrefabs, ShotPointPosion2.position, ShotPointPosion2.rotation);
        NewShell1.GetComponent<Rigidbody>().velocity = NewShell1.transform.forward * ShellPower;
        NewShell2.GetComponent<Rigidbody>().velocity = NewShell2.transform.forward * ShellPower;
    }
}
