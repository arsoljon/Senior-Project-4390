using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InventoryReset : MonoBehaviour
{
    //Manage the inventory items and count of players respawned. 
    GameObject player;
    GameObject playerClone;   
    public CinemachineVirtualCameraBase cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null && playerClone == null)
        {
            Reset();
            playerClone = GameObject.Find("Player(Clone)");
        }
        //destroy all extra player gameobjects. 
        if(GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length);
            int count = 0; 
            foreach(GameObject child in GameObject.FindGameObjectsWithTag("Player"))
            {
                if (count > 0)
                {
                    LevelManager.instance.Respawn();
                }
                Destroy(child); 
                count++;
            }
        }
    }

    private void Reset() {
        foreach(Transform child in transform) {
            if(child.gameObject.tag == "InventorySlot"){
                foreach(Transform grandchild in child)
                {
                    Destroy(grandchild.gameObject);
                }
            }
        }
    }
}
