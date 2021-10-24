using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //Different fish should have differnt _speed and different frequencies. 
    //Frequency represents how quick it floats down/up
    //Amplitude represents how high/low
    float distanceAway = 20.0f;
    public float speed {get{return _speed;}}
    public float amps {get{return _amplitude;}}
    public float freq {get{return _frequency;}}
    public float _speed;
    float _amplitude;
    float _frequency;
    float _origin;
    Rigidbody controller;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        _frequency = Random.Range(0.8f, 2.0f);
        _amplitude = Random.Range(0.3f, 0.7f);
        _speed = Random.Range(1.0f, 5.0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Move X", 0);
    }

    void FixedUpdate()
    {
        animator.SetFloat("Move X", _speed);
        Vector2 position = transform.position;
        position.x = position.x + _speed * Time.deltaTime;
        //Make the sin wave inconsistently go up and down. 
        position.y = Mathf.Sin(Time.time * _frequency) * _amplitude;
        transform.position = position;
    }
}
