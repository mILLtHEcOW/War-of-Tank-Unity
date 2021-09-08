using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthPlayer : Health
{
    private int maxHealth = 50;
    [SerializeField]private int health;
    public GameObject deadEffect;
    public Healthbar bar=> GetComponent<Healthbar>();
    public int lives = 2;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = this.transform.position;
        health = maxHealth;
        bar.SetMaxHealth(maxHealth);
    }

    public override void ApplyDamage(int damage) //处理伤害
    {
        if (health > damage)
        {
            health -= damage;
            bar.SetHealth(health);//修改生命条
        }
        else if(lives>0)
        {
            Destruct();//摧毁
            Respawn();//重生
        }
        else
        {
            Lose();//游戏失败
        }
        
    }
    void Respawn()
    {
        this.gameObject.transform.position = spawnPoint;
        health = maxHealth;
        bar.SetHealth(maxHealth);
        GetComponent<TankSwitchPart>().SwitchTurret(0);
        GetComponentInChildren<TankShotInput>().isReady = true;
        lives--;
    }

    private void Destruct() //坦克摧毁后播放效果
    {        
        GameObject Dead = Instantiate(deadEffect, transform.position, transform.rotation) as GameObject;
        Destroy(Dead, 2f);
    }

    public void Lose()
    {
        VictoryLose.isLose = true;
    }
}
