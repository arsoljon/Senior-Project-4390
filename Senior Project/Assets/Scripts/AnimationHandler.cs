using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private CharacterMovement movement;
    private Animator animator;

    private Transform localTransform;

    private bool isFacingRight = true;
    
    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();

        localTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        float moveDir = movement.MoveDirection.x;
        
        animator.SetFloat("Speed", Math.Abs(moveDir));

        if (moveDir > 0 && !isFacingRight)
            ChangeSpriteFacing();
        else if (moveDir < 0 && isFacingRight)
            ChangeSpriteFacing();
    }
    
    private void ChangeSpriteFacing()
    {
        isFacingRight = !isFacingRight;
        
        Vector3 newScale = localTransform.localScale;
        newScale.x *= -1;

        localTransform.localScale = newScale;
    }
}
