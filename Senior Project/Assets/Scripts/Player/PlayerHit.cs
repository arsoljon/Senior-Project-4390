using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Fish")
        {
            Debug.Log("Fish hit");
            other.gameObject.GetComponent<FishHealth>().ChangeHealth(-1);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Fish")
            {
                FishHealth fish = other.gameObject.GetComponent<FishHealth>();
                if (fish != null)
                {
                    fish.ChangeHealth(-1);
                    Debug.Log(fish.health);
                }   
            }
    }
}
