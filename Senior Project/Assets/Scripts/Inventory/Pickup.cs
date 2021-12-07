using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    //When player collides with item
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //check whether inventory is full of items or not
            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                {
                    // makes sure that the slot is now considered FULL
                    inventory.items[i] = 1; 
                    // spawn the button so that the player can interact with it/bring to existance
                    Instantiate(itemButton, inventory.slots[i].transform, false); 
                    Destroy(gameObject);
                    break;
                }
            }
        }

    }
}
