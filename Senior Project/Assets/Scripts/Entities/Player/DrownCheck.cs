using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownCheck : MonoBehaviour
{
    bool isUnderWater; 
    [SerializeField]float maxTimeUnderWater = 3f;
    [SerializeField]int maxDamage = 10;
    [SerializeField]float resetDamageTimer = 5f;
    float damageTimer = 1f;
    float remainingBreath; 


    // Start is called before the first frame update
    void Start()
    {
        remainingBreath = maxTimeUnderWater;
        damageTimer = resetDamageTimer;
    }

    // Update is called once per frame
    void Update()
    {
        UnderWaterStatus();
    }

    public void UnderWaterStatus()
    {
        if(isUnderWater)
        {
            if (remainingBreath > 0f){
                remainingBreath -= Time.deltaTime;
            }
        }
        else{
            if(remainingBreath < maxTimeUnderWater){
                remainingBreath = remainingBreath + Time.deltaTime;
            }
            damageTimer = resetDamageTimer;
        }
        //Only do damage after a given amount of time. 
        if(isUnderWater && remainingBreath < 0f){
            if(damageTimer < 0f)
            {
                Health health = gameObject.GetComponent<Health>();
                if(health != null)
                {
                    health.TakeDamage(maxDamage);
                }
                damageTimer = resetDamageTimer;
            }
            damageTimer = damageTimer - Time.deltaTime;
        }
        UIAirBar.instance.SetValue(remainingBreath / maxTimeUnderWater);
    }


    //check under water status
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Underwater") isUnderWater = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Underwater") isUnderWater = false;
    }
}
