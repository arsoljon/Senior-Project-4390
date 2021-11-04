using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimBoundaryController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Fish"){
            other.gameObject.GetComponent<FishController>()._speed = -other.gameObject.GetComponent<FishController>()._speed;  
        }
    }

}
