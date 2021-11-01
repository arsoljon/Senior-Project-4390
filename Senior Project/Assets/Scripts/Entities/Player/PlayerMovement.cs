using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    private void Update()
    {
        
        MoveDirectionX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            IsJumping = true;
        }
    }
}
