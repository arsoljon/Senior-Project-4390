using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 MoveDirection => moveDirection;
    
    [Header("Movement")] 
    [SerializeField] private Vector2 moveDirection = new Vector2(0, 0);
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Components")] [SerializeField]
    private Transform groundCheck;

    [SerializeField] private float groundCheckRadius = .2f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private Transform submersedCheck;
    [SerializeField] private float submersedCheckRadius = .5f;
    [SerializeField] private LayerMask whatIsWater;

    private Rigidbody2D rb2d;

    private bool isGrounded;
    private bool isTouchingWaterbody, isTouchingShoreline;
    
    private float moveSpeed;
    private float initialGravity;

    private float xVelocity, yVelocity;
    
    public bool IsRunning
    {
        set => moveSpeed = value ? runSpeed : walkSpeed;
    }
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveSpeed = walkSpeed;
        initialGravity = rb2d.gravityScale;
    }
    
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        xVelocity = moveDirection.x * moveSpeed;

        if (isTouchingWaterbody)
        {
            rb2d.gravityScale = 0;
            yVelocity = moveDirection.y * moveSpeed;

            if (isTouchingShoreline)
            {
                yVelocity += 5;
            }
        }
        else
        {
            rb2d.gravityScale = initialGravity;
            yVelocity = rb2d.velocity.y;
        }

        rb2d.velocity = new Vector2(xVelocity, yVelocity);
    }
    
    public void Move(Vector2 direction)
    {
        moveDirection = direction;
    }

    public void Jump()
    {
        if (isGrounded)
            rb2d.velocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaterBody")) isTouchingWaterbody = true;
        if (other.CompareTag("Shoreline")) isTouchingShoreline = true;
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("WaterBody")) isTouchingWaterbody = false;
        if (other.CompareTag("Shoreline")) isTouchingShoreline = false;
    }
    
}