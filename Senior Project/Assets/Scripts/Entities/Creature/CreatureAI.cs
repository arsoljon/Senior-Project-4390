using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterMovement))]
public class CreatureAI : MonoBehaviour
{
    [SerializeField] private CharacterMovement movement;
    
    [SerializeField] private Transform target;
    
    [SerializeField] private float _maxTargetDistance = 5f;
    [SerializeField] private float _minTargetDistance = 2.5f;
    
    private Vector2 targetDir;
    
    public UnityEvent targetIsNear;
    
    private void Awake()
    {
        movement = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (!target) return;
        
        Vector2 targetPos = target.position;
        Vector2 currentPos = transform.position;

        Vector2 unitTargetDirection = GetTargetDirection(targetPos, currentPos);
        movement.Move(unitTargetDirection);
    }

    private Vector2 GetTargetDirection(Vector2 toPosition, Vector2 fromPosition)
    {
        Vector2 direction = toPosition - fromPosition;
        float distanceToTarget = direction.magnitude;

        if (distanceToTarget < _maxTargetDistance)
        {
            if (distanceToTarget <= _minTargetDistance)
            {
                targetIsNear?.Invoke();
                return Vector2.zero;
            }
            
            return direction.normalized;
        }
        
        return Vector2.zero;
    }
}
