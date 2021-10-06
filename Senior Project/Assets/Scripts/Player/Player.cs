using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private PlayerInput input;
    private PlayerActions actions;

    [SerializeField]
    private PlayerStats stats;

    [SerializeField]
    private PlayerComponents components;

    public PlayerComponents Components { get { return components; } }
    public PlayerActions Actions { get { return actions; } }
    public PlayerStats Stats { get { return stats; } }

    private void Awake() {
        input = new PlayerInput(this);
        actions = new PlayerActions(this);

        stats.Speed = stats.WalkSpeed;
    }

    private void Update() {
        input.HandleInput();
    }

    private void FixedUpdate() {
        actions.Move(transform);
    }
}
