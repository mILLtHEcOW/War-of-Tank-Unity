using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotPoint : MonoBehaviour,ITankShotInput
{
    public GameObject ShellPrefabs;
    public Transform ShotPointPosion;
    private float ShellPower = 20;
    public Animator anim;
    public GameObject cannon;
    public GameObject mouse;
    public KeyCode FiringKey;

    private void FixedUpdate()
    {
        cannon.transform.LookAt(mouse.transform);//武器朝向
    }

    public void Shoot()
    {
        anim.SetTrigger("Fire");
        GameObject newShell = Instantiate(ShellPrefabs, ShotPointPosion.position, ShotPointPosion.rotation);
        newShell.GetComponent<Rigidbody>().velocity = newShell.transform.forward * ShellPower;
        Destroy(newShell, 2f);
    }
    

}
