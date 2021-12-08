using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    int maxDamage; 
    float health; 
    bool playerHit; 
    float playerHitTimer;
    float maxHitTimer;
    // Start is called before the first frame update
    void Start()
    {
        maxDamage = 10; 
        playerHitTimer = 0f;
        maxHitTimer = 0.5f;
        playerHit = false;
    }


    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            Health playerHealth = other.gameObject.GetComponent<Health>();
            if(playerHealth != null)
            {
                if(playerHit == false)
                {
                    playerHealth.TakeDamage(maxDamage);
                    playerHit = true;
                }
                else
                {
                    if(playerHitTimer >= maxHitTimer){
                        playerHit = false;
                        playerHitTimer = 0f;
                    }
                    else
                        playerHitTimer += Time.deltaTime;
                }   
            }
        }

        if(other.gameObject.tag == "Fish")
        {
            FishHealth fish = other.gameObject.GetComponent<FishHealth>();
            if (fish != null)
            {
                fish.ChangeHealth(maxDamage);
            }   
        }
    }
}
