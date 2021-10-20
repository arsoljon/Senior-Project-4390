using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("health: " + gameObject.GetComponent<PlayerController>().health);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<PlayerController>().health <= 0){
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }
}
