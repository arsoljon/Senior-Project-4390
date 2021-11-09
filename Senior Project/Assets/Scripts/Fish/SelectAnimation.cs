using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnimation : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<FishController>()._speed > 0)
            animator.SetFloat("Move X", -1);
        else
            animator.SetFloat("Move X", 1);
        if(gameObject.GetComponent<FishHealth>().isDead == true)
        {
            animator.SetFloat("Move X", 3);
            //position.y = position.y + (Time.deltaTime/2);
            //transform.position = position;
        }
    }
}
