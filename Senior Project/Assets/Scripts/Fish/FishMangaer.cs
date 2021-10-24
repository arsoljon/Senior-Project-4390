using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManagaer : MonoBehaviour
{
    public PlayerController player;
    float distanceAway;
    float _origin;
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        distanceAway = 20.0f;
        speed = Random.Range(1.0f, 5.0f);
        foreach(Transform child in gameObject.transform)
        {
            if(child.tag == "Fish")
            {
                Vector2 position = child.transform.position;
                position.x = (player.transform.position.x + 10.0f) - distanceAway;
                position.y = Random.Range(-1f, 7f);
                child.transform.position = position;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in gameObject.transform)
            {
                if(child.tag == "Fish")
                {
                    if(child.transform.position.x > (player.transform.position.x + distanceAway) || child.transform.position.x < (player.transform.position.x - distanceAway))
                    {
                        child.GetComponent<FishController>()._speed = -child.GetComponent<FishController>()._speed; 
                    }
                }
            }
    }
}
