using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float x;
    public float y;

    public float airTimer;
    public float air;

    public bool jumping;
    public bool grounded;
    public bool facingRight;

    public PlayerData(GameObject player)
    {
//        health = player.GetComponent<PlayerController>().currentHealth;
    }

}
