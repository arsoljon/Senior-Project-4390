using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int index;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    //updates slot index once its been removed to use slot for another item
    private void Update()
    {
        //if slot is empty
        if (transform.childCount <= 0)
        {
            //then update slot to 0
            inventory.items[index] = 0;
        }
    }
    //when pressing the red cross
    public void DropItem() 
    {
        //run a number of times equal to children inside slot
        foreach (Transform child in transform)
        {
            //item will be dropped inside the scene again when function is called
            child.GetComponent<Spawn>().SpawnDroppedItem();
            //destroy each child of slot
            GameObject.Destroy(child.gameObject);
        }
    }
}
