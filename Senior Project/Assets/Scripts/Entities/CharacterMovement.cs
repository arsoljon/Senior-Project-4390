using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    private float moveSpeed;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Vector2 moveDirection = new Vector2(0, 0);
    
    [Header("Components")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = .2f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb2d;
    private Animator animator;

    private bool isFacingRight = true;
    private bool isGrounded = true;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        moveSpeed = walkSpeed;
    }
    
    private void FixedUpdate()
    {
        float horizontal = moveDirection.x;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (horizontal > 0 && !isFacingRight) {
            ChangeSpriteFacing();
        } else if (horizontal < 0 && isFacingRight) {
            ChangeSpriteFacing();
        }

        CheckIfGrounded();
    }

    public void Move(float directionX, float directionY)
    {
        moveDirection.x = directionX;
        
        rb2d.velocity = new Vector2(directionX * moveSpeed, rb2d.velocity.y);
    }

    public void Jump() 
    {
        if (isGrounded)
        {
            rb2d.velocity += Vector2.up * jumpForce;
        }
    }

    private void ChangeSpriteFacing()
    {
        isFacingRight = !isFacingRight;
        
        var localTransform = transform;
        
        Vector3 newScale = localTransform.localScale;
        newScale.x *= -1;

        localTransform.localScale = newScale;
    }
    
    private void CheckIfGrounded() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
