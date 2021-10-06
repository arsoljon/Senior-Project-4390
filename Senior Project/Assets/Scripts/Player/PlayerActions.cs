using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions {
	private Player player;

	public PlayerActions(Player player) {
		this.player = player;
	}

	public void Move(Transform transform) {
		float horizontalStep = player.Stats.Direction.x * player.Stats.Speed * Time.fixedDeltaTime;
		float verticalStep = player.Stats.Direction.y;
		player.Components.RigidBody.velocity = new Vector2(horizontalStep, verticalStep);
	}
}