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
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.Move(horizontal, vertical);
        movement.IsRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump"))
        {
            movement.Jump();
        }
    }
}
