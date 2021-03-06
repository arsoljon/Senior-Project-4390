using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    //These variables will keep track if the item should be shown. 
    public bool isGone {get{return gone;}}
    bool gone;
    // Start is called before the first frame update
    void Start()
    {
        gone = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Health health = player.GetComponent<Health>();
        if(health != null)
        {
            if(health.GetHealthPercent() < health.GetMaxHealth())
            {
                health.Heal(10);
                gone = true;
            }
        }
    }
/*
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gone == false)
        {
            if(other.gameObject.tag == "Player")
            {
                Health health = other.GetComponent<Health>();
                if(health != null)
                {
                    if(health.GetHealthPercent() < health.GetMaxHealth())
                    {
                        health.Heal(10);
                        gone = true; 
                    }
                }
            }
        }
    }
*/
    public void ResetGone()
    {
        gone = false;
    }
}
