using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotPointHeavy : MonoBehaviour,ITankShotInput
{
    public Transform TankShotPoint1;
    public Transform TankShotPoint2;
    public GameObject ShellPrefabs;
    public KeyCode FiringKey = KeyCode.Mouse0;
    [SerializeField]
    private float ShellPower = 20;
    public Animator anim;
    public GameObject cannon;
    public GameObject mouse;

    private void FixedUpdate()
    {
        cannon.transform.LookAt(mouse.transform);
    }

    public void Shoot()
    {
        anim.SetTrigger("Fire");
        GameObject newShell1 = Instantiate(ShellPrefabs, TankShotPoint1.position, TankShotPoint1.rotation);
        GameObject newShell2 = Instantiate(ShellPrefabs, TankShotPoint2.position, TankShotPoint2.rotation);
        newShell1.GetComponent<Rigidbody>().velocity = newShell1.transform.forward * ShellPower;
        newShell2.GetComponent<Rigidbody>().velocity = newShell2.transform.forward * ShellPower;
        Destroy(newShell1, 2f);
        Destroy(newShell2, 2f);
    }
    

}