using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealthEnemy : Health
{
    private int maxHealth = 20;
    [SerializeField] private int health;
    public GameObject deadEffect;
    public Healthbar bar;
    public int lives = 2;
    public GameObject lightTurret;
    public GameObject mediumTurret;
    public GameObject heavyTurret;
    public Vector3 spawnPoint;
    private void Start()
    {
        spawnPoint = this.transform.position;
        bar = GetComponent<Healthbar>();//把HealthBar添加到TankPrefabs
        health = maxHealth;
        bar.SetMaxHealth(maxHealth);
    }

    public override void ApplyDamage(int damage) //处理伤害
    {
        if (health > damage)
        {
            health -= damage;
            bar.SetHealth(health);
        }
        else if (lives > 0)
        {
            Destruct();
            Spawn();
        }
        else
        {
            Destruct();
            Destroy(this.gameObject);
        }

    }

    void Spawn()
    {
        switch (lives)
        {
            case 1:
                mediumTurret.SetActive(false);
                heavyTurret.SetActive(true);
                break;
            case 2:
                lightTurret.SetActive(false);
                mediumTurret.SetActive(true);
                break;
        }
        this.transform.position = spawnPoint;
        health = maxHealth;
        bar.SetHealth(health);
        lives--;
    }
    private void Destruct() //坦克摧毁后播放效果
    {
        GameObject Dead = Instantiate(deadEffect, transform.position, transform.rotation) as GameObject;
        Destroy(Dead, 2f);
    }

    
}
