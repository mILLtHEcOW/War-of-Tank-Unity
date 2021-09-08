using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    //public float MoveSpeed = 3f;    //AI坦克移动速度    
    //public float AttackRange = 15f;  //AI坦克的攻击距离,距离dist大于这个值开始移动
    //public float SherchRange = 40f ;  //坦克搜索范围
    private GameObject Player;  //目标 
    private GameObject Base;
    public EnemyShot ES;
    private bool canShoot=true;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        Base = GameObject.FindWithTag("Base");
    }
    private void Start()
    {
        ES = GetComponentInChildren<EnemyShot>();
        //StartCoroutine(EnemyShoot());
    }

    public IEnumerator EnemyShoot()
    {
        if (canShoot)
            canShoot = false;
        yield return new WaitForSeconds(Random.Range(2, 4));
        ES.Shoot();
        canShoot = true;
    }
    

    //private void FixedUpdate()
    //{     
    //    float dist = Vector3.Distance(Player.transform.position, this.transform.position);  //Vector3.Distance函数计算AI坦克与玩家坦克的距离
    //    if (dist < SherchRange)
    //    {
    //        if (dist > AttackRange)
    //        {
    //            transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime);
    //        }                        
    //        transform.LookAt(Player.transform); //面向玩家坦克
            
    //    }

    //}
}