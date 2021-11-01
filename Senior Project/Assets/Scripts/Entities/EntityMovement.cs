using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    private float moveSpeed;

    [SerializeField] private float jumpForce = 5f;

    [Header("Components")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = .5f;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D rb2d;
    private Animator animator;
    
    protected float MoveDirectionX;
    private bool isFacingRight = true;
    
    protected bool IsJumping = false;
    private bool isGrounded = true;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        moveSpeed = walkSpeed;
    }
    
    private void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(MoveDirectionX));
           
        Move();
        
        if (MoveDirectionX > 0 && !isFacingRight) {
            ChangeSpriteFacing();
        } else if (MoveDirectionX < 0 && isFacingRight) {
            ChangeSpriteFacing();
        }

        CheckIfGrounded();
        
        if (IsJumping && isGrounded)
        {
            IsJumping = false;
            
            Jump();
        }
    }

    private void Move()
    {
        rb2d.velocity = new Vector2(MoveDirectionX * moveSpeed, rb2d.velocity.y);
    }
    
    private void Jump() 
    {
        rb2d.velocity += Vector2.up * jumpForce;
    }

    private void ChangeSpriteFacing()
    {
        isFacingRight = !isFacingRight;
        
        var localTransform = transform;
        
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;

        localTransform.localScale = newScale;
    }
    
    private void CheckIfGrounded() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, whatIsGround);

        isGrounded = false;
        foreach (Collider2D coll in colliders) {
            if (coll.gameObject != gameObject) 
                isGrounded = true;
        }
    }
}
