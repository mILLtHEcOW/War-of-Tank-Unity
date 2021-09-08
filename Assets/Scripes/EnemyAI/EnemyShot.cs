using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour,IEnemyShot
{
    public GameObject ShellPrefabs;
    public Transform ShotPointPosion;
    public float ShellPower = 20;
    public Animator anim;
    public void Shoot()
    {
        anim.SetTrigger("Fire");
        GameObject newShell = Instantiate(ShellPrefabs, ShotPointPosion.position, ShotPointPosion.rotation);
        newShell.GetComponent<Rigidbody>().velocity = newShell.transform.forward * ShellPower;
        Destroy(newShell,2f);
    }
}
