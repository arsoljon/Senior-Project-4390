using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //Different fish should have differnt speed and different frequencies. 
    //Frequency represents how quick it floats down/up
    //Amplitude represents how high/low
    float speed;
    float distanceAway = 20.0f;
    float _amplitude;
    float _frequency;
    float _origin;
    public PlayerController player;
    Rigidbody controller;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.0f, 5.0f);
        _frequency = Random.Range(0.8f, 2.0f);
        _amplitude = Random.Range(0.3f, 0.7f);
        Vector2 position = transform.position;
        position.x = player.transform.position.x - distanceAway;
        position.y = Random.Range(-1f, 7f);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > (player.transform.position.x + distanceAway))
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = position.x + speed * Time.deltaTime;
        //Make the sin wave inconsistently go up and down. 
        position.y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        transform.position = position;
    }
}
