using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShotPoint : MonoBehaviour
{
    public GameObject ShellPrefabs;    
    public Transform ShotPointPosion;    
    public KeyCode FiringKey;
    [SerializeField]
    private float ShellPower = 20;
    public Animator anim;
    public GameObject cannon;
    public GameObject mouse;

    //private AudioSource FiringAudio;
    private void FixedUpdate()
    {
        cannon.transform.LookAt(mouse.transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(FiringKey))
        {
            Shoot();
        }        
    }

    public void Shoot()
    {
        anim.SetTrigger("Fire");        
        GameObject NewShell = Instantiate(ShellPrefabs, ShotPointPosion.position, ShotPointPosion.rotation) ;
        NewShell.GetComponent<Rigidbody>().velocity = NewShell.transform.forward * ShellPower;
       
    }

    



}
