using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //Different fish should have differnt _speed and different frequencies. 
    //Frequency represents how quick it floats down/up
    //Amplitude represents how high/low
    public float speed {get{return _speed;}}
    public float amps {get{return _amplitude;}}
    public float freq {get{return _frequency;}}
    public float _speed;
    public float _k; 
    float _amplitude;
    float _frequency;
    Rigidbody2D rigidbody2d;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent = GameObject.Find("FishSpawnArea");
        transform.parent = Parent.transform;
        //_k will adjust the y-value as neccessary. 
        _k = 0;
        _frequency = Random.Range(0.8f, 1.3f);
        _amplitude = Random.Range(0.01f, 0.05f);
        _speed = Random.Range(1.0f, 5.0f);
        //direction will go left or right
        int[] direction = new int[] {-1, 1};
        int pick = Random.Range(0,2);
        if(pick == 2)
            pick = 1;
        _speed *= direction[pick];

        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Move X", 0);
    }

    void FixedUpdate()
    {
        if(_speed > 0)
            animator.SetFloat("Move X", -1);
        else
            animator.SetFloat("Move X", 1);
        Vector2 position = rigidbody2d.position;
        position.x = position.x + _speed * Time.deltaTime;
        position.y = Mathf.Sin((Time.time) * _frequency) * _amplitude + position.y;
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //check if a fish hits another fish and move them so they do not get stuck together. 
        if(other.gameObject.tag == "Fish")
        {
            _k += 1;
            other.gameObject.GetComponent<FishController>()._k -= 1;
        }
    }
}
