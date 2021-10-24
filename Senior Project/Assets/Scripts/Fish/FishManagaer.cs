using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMangaer : MonoBehaviour
{
    public PlayerController player;
    float distanceAway;
    float _origin;
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            if(child.tag == "Fish")
            {
                child.transform.position = ChangePosition(child.transform.position, child.GetComponent<FishController>().freq, child.GetComponent<FishController>().amps);
            }
        }
        distanceAway = 20.0f;
        speed = Random.Range(1.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform child in gameObject.transform)
            {
                if(child.tag == "Fish")
                {
                    if(child.transform.position.x > (player.transform.position.x + distanceAway))
                    {
                        speed = -speed; 
                        child.transform.position = ChangePosition(child.transform.position, child.GetComponent<FishController>().freq, child.GetComponent<FishController>().amps);
                    }
                }
            }
    }

    Vector2 ChangePosition(Vector2 position, float _frequency, float _amplitude)
    {
        position.x = position.x + speed * Time.deltaTime;
        //Make the sin wave inconsistently go up and down. 
        position.y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        return position;
    }
}
