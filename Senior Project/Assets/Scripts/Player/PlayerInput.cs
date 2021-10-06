using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput {
    Player player;

    public PlayerInput(Player player) {
        this.player = player;
    }

    public void HandleInput() {
        float verticalMovement = player.Components.RigidBody.velocity.y;
        player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), verticalMovement);
    }
}
