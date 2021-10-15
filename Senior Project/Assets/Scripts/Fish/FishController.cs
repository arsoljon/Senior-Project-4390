using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    float speed = 3.0f;
    float distanceAway = 20.0f;
    float _amplitude = 0.5f;
    float _frequency = 2.0f;
    public PlayerController player;
    Rigidbody controller;
    // Start is called before the first frame update
    void Start()
    {
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
        position.y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        transform.position = position;
    }
}
