using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : MonoBehaviour

{
    private float MoveSpeed = 5;    //AI坦克移动速度
    [SerializeField]
    private GameObject Player ;  //目标
    [SerializeField]
    private float AttackRange = 15;  //AI坦克的攻击距离,距离dist大于这个值开始移动
    [SerializeField]
    private float SherchRange = 40 ;  //坦克搜索范围
    [SerializeField]
    private float Timer;  //计时器
    [SerializeField]
    private float ShootCoolDown; //射击冷却时间

    

    private void Start()
    {
       
    }

    private void FixedUpdate()
    {
        Timer += Time.fixedDeltaTime;
        if (Player == null)
            return;
                 
        float dist = Vector3.Distance(Player.transform.position, this.transform.position);  //Vector3.Distance函数计算AI坦克与玩家坦克的距离
        if (dist < SherchRange)
        {
            if (dist > AttackRange)
            {
                transform.Translate(new Vector3(0, 0, 1) * MoveSpeed * Time.deltaTime);
            }                        
            transform.LookAt(Player.transform); //面向玩家坦克
            
        }
        this.GetComponent<Rigidbody>().velocity = transform.positioni;

    }

  
}