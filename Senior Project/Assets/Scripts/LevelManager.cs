using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform respawnPoint; 
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    private void Awake() {
        instance = this;
    }

    public void Respawn () {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
        int maxHealth = 100;
        player.GetComponent<Health>().Heal(maxHealth);
        //Re-initialize the slot values in the players inventory component
        GameObject [] listofSlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        Inventory inventory = player.GetComponent<Inventory>();
        for(int i = 0; i < inventory.slots.Length; ++i)
        {
            inventory.slots[i] = listofSlots[i];
        }
    }
}
