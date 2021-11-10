using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Transform player;
    public GameObject item;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    //funtion to drop item a near player position
    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x + 3, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}

