using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] private int health;


    public event Action OnDied;

    private void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Died(); //invoke died event
        }
        UIHealthBar.instance.SetValue(health / (float)maxHealth);
        // invoke damaged event
    }

    public void Heal(int amount)
    {
        health += amount;

        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        UIHealthBar.instance.SetValue(health / (float)maxHealth);
        // invoke recovery event
    }

    public float GetHealthPercent()
    {
        return health / (float)maxHealth;
    }

    private void Died()
    {
        Destroy(gameObject);
        OnDied?.Invoke();
        LevelManager.instance.Respawn();
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
