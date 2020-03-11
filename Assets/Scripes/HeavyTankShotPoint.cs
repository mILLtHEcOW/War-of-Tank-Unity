using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyTankShotPoint : MonoBehaviour
{
    public Transform TankShotPoint1;
    public Transform TankShotPoint2;
    public GameObject ShellPrefabs;
    public KeyCode FiringKey;
    [SerializeField]
    private float ShellPower = 20;
    public Animator anim;
    public GameObject cannon;
    public GameObject mouse;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            HeavyShoot();
        }
    }
    private void FixedUpdate()
    {
        
        cannon.transform.LookAt(mouse.transform);
    }

    public void HeavyShoot()
    {

        anim.SetTrigger("Fire");
        GameObject NewShell1 = Instantiate(ShellPrefabs, TankShotPoint1.position, TankShotPoint1.rotation);

        GameObject NewShell2 = Instantiate(ShellPrefabs, TankShotPoint2.position, TankShotPoint2.rotation);

        NewShell1.GetComponent<Rigidbody>().velocity = NewShell1.transform.forward * ShellPower;

        NewShell2.GetComponent<Rigidbody>().velocity = NewShell2.transform.forward * ShellPower;
    }

}
    
  

