using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetTrigger("Attack1");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
