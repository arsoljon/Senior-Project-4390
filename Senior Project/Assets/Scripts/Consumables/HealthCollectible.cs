using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            Debug.Log("Symbolic health increase!");
            /*
            //Make these inside of the PlayerController script. 
            if(controller.health  < controller.maxHealth)
            {
                //Make this too. ChangeHealth function. 
                controller.ChangeHealth(1);
            }
            */
        } 
    }
}
