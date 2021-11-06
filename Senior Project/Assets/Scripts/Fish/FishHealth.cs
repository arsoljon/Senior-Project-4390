using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int health { get { return currentHealth; }}
    int currentHealth;
    
    public bool isDead = false;

    float waterLevel = -2f;
    bool isUnderWater; 
    float maxTimeUnderWater = 3f;
    float remainingBreath; 
    float damageTimer = 1f;
    float resetDamageTimer = 1f;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int amount)
    {   
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}
