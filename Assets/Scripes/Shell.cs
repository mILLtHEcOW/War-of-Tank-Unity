using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionTimeUP;    
    public LayerMask enemyTank;    
    public int damage;

    

    private void Start()
    {
        
    }

    void OnCollisionEnter()
    {
        //TankHealth health = GetComponent<TankHealth>();
        //health.ApplyDamage(damage);
        GameObject obj = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;        
        Destroy(gameObject);
        Destroy(obj, explosionTimeUP);//摧毁炮弹
    }

        

}


