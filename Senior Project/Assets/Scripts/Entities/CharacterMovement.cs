using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")] [SerializeField] private Vector2 moveDirection = new Vector2(0, 0);
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Components")] [SerializeField]
    private Transform groundCheck;

    [SerializeField] private float groundCheckRadius = .2f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private Transform submersedCheck;
    [SerializeField] private float submersedCheckRadius = .2f;
    [SerializeField] private LayerMask whatIsWater;

    private Rigidbody2D rb2d;

    private bool isGrounded;
    private bool isUnderwater;
    private float moveSpeed;

    public Vector2 MoveDirection => moveDirection;

    public bool IsRunning
    {
        set => moveSpeed = value ? runSpeed : walkSpeed;
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isUnderwater = Physics2D.OverlapCircle(submersedCheck.position, submersedCheckRadius, whatIsWater);

        if (isUnderwater)
        {
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector2(rb2d.velocity.x, moveDirection.y * moveSpeed);
        }
        else
        {
            rb2d.gravityScale = 1.4f;
        }
    }

    public void Move(float directionX, float directionY)
    {
        moveDirection.x = directionX;
        moveDirection.y = directionY;

        rb2d.velocity = new Vector2(directionX * moveSpeed, rb2d.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
            rb2d.velocity += Vector2.up * jumpForce;
    }
}