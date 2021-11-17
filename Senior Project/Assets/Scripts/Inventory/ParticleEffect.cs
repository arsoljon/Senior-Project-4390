using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    bool gone; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gone = false; 
    }

    public void Use()
    {
        //discover the type of item and deal the proper damage. 
        GameObject item = gameObject.GetComponent<Spawn>().item;
        Health playerHealth = player.GetComponent<Health>(); 
        if(item.GetComponent<Damage>() != null)
        {
            item.GetComponent<Damage>().ChangeHealth();
        }
        else if(item.GetComponent<HealthCollectible>() != null)
        {
            item.GetComponent<HealthCollectible>().ChangeHealth();
        }
        
        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);           
    }
}
