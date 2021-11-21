using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class CreatureAI : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;
    [SerializeField] private Transform target;

    [SerializeField] private float _maxTargetDistance = 5f;
    [SerializeField] private float _minTargetDistance = 2.5f;
    
    private Vector2 targetDir;
    
    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        if (!target) return;
        
        Vector2 targetPos = target.position;
        Vector2 currentPos = transform.position;

        Vector2 targetDirection = targetPos - currentPos;
        Vector2 unitTargetDirection = targetDirection.normalized;
        float distanceToTarget = targetDirection.magnitude;

        if (distanceToTarget < _minTargetDistance || distanceToTarget > _maxTargetDistance)
        {
            movement.Move(Vector2.zero);
            return;
        }
        
        movement.Move(unitTargetDirection);
    }

    private void MoveToTarget()
    {
        movement.Move(targetDir.normalized);
    }
}
