using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;

    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        movement.Move(moveDirection);
        movement.IsRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump"))
        {
            movement.Jump();
        }
    }
}
