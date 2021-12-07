using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAttack : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private int hitDamage = 20;
    [SerializeField] private float timePerAttack = 1f;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    
    private bool isAttacking = false;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timePerAttack);
        
        isAttacking = false;
    }
    
    public void Attack()
    {
        if (isAttacking) return;
        isAttacking = true;
        
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(hitDamage);
        }

        StartCoroutine(AttackCooldown());
    }
}
