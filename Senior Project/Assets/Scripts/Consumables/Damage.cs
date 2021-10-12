using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController controller = other.GetComponent<PlayerController>();

        if(controller != null)
        {
            Debug.Log("Symbolic health decrease!");
            /*
            if(controller.health > 0 && controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(-1);
            }
            */
        }
    }
}
