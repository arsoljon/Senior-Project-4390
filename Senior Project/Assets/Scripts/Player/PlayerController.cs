using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform groundCheck;

    [SerializeField] private float moveSpeed = 180f;
    [SerializeField] private float jumpForce = 200f;

    private Animator animator;

    private float moveSmoothing = 0.05f;

    private float directionX = 0f;
    private Vector2 currentVelocity = Vector2.zero;

    private bool isFacingRight = true;
    private bool isGrounded = true;
    private bool isJumping = false;


    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        directionX = horizontal * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
        }
    }

    private void FixedUpdate() {
        Move();

        if (directionX > 0 && !isFacingRight) {
            FlipSprite();
        } else if (directionX < 0 && isFacingRight) {
            FlipSprite();
        }

        GroundedCheck();

        if (isJumping && isGrounded) {
            Jump();
        }
    }

    private void GroundedCheck() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .06f, LayerMask.GetMask("Ground"));

        foreach (Collider2D collider in colliders) {
            if (collider.gameObject != gameObject) isGrounded = true;
        }
    }

    private void Move() {
        float horizontalMoveStep = directionX * Time.fixedDeltaTime;
        float verticalVelocity = _rigidbody.velocity.y;

        Vector2 targetVelocity = new Vector2(horizontalMoveStep, verticalVelocity);
        _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref currentVelocity, moveSmoothing);
    }

    private void Jump() {
        isGrounded = false;

        _rigidbody.AddForce(new Vector2(0f, jumpForce));
        isJumping = false;
    }

    private void FlipSprite() {
        isFacingRight = !isFacingRight;

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;

        transform.localScale = newScale;
    }
}