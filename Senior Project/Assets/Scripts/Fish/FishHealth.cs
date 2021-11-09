using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHealth : MonoBehaviour
{
    int maxHealth = 2;
    public int health { get { return currentHealth; }}
    int currentHealth;
    public bool isDead;
    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invincibleTimer;

    void Awake()
    {
        currentHealth = maxHealth;
        isInvincible = false;
        isDead = false;
    }

    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {   
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        Debug.Log("Fish Health : " + currentHealth);
    }
}
