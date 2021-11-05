using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimBoundaryController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Fish"){
            //Spawn the fish away from the border so its new location is not outside the border. 
            Vector2 position = other.gameObject.transform.position;
            other.gameObject.transform.position = position;
            float change = 10f;
            if (other.gameObject.GetComponent<FishController>().speed > 0)
            {
                position.x -= change; 
            } else
            {
                position.x += change;
            }
            //Change direction of fish. 
            other.gameObject.GetComponent<FishController>()._speed = -other.gameObject.GetComponent<FishController>()._speed;  
        }
    }

    

}
