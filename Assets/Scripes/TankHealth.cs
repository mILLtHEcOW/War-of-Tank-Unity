using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    public int health = 100;
    public GameObject deadEffect;//坦克摧毁后的特效
   
    public void ApplyDamage(int damage) //处理伤害
    {
        if (health > damage)
            health -= damage;
        else
            Destruct();
    }
    public void Destruct() //坦克摧毁后播放效果
    {
        if (deadEffect != null)
        {
            GameObject Dead = Instantiate(deadEffect, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }

}
