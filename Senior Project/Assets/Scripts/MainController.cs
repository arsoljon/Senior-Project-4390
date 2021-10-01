using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //This rigidbody2d refers to the component in the inspector when clicking the main character. 
    public float speed = 5.0f;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        //rigidbody2d.MovePosition(position);
        transform.position = position;
    }
    
    void FixedUpdate() 
    {
        
    }
}
