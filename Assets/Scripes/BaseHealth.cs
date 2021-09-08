using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Eenemy
}

public class BaseHealth : Health
{
    private int maxHealth = 100;
    [SerializeField] private int health;
    public Healthbar bar;
    public Team team = Team.Player;

    private void Start()
    {
        bar = GetComponent<Healthbar>();
        bar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    public override void ApplyDamage(int damage) //处理伤害
    {
        if (health > damage)
        {
            health -= damage;
            bar.SetHealth(health);
        }
        else if (team == Team.Player)
            YouLose();
        else if (team == Team.Eenemy)
            YouWin();
    }

    public void YouLose()
    {
        VictoryLose.isLose = true;
    }
    public void YouWin()
    {
        VictoryLose.isWin = true;
    }
}
