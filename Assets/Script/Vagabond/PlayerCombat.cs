using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Basic Attack")]
    public Animator anim;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int noOfClick = 0;
    float lastClickedTime = 0;
    public float maxComboDelay = 0.5f;

    [Header("Charge Attack")]
    public float power;
    float maxPower = 5;
    bool buttonHeldDown;


    private void Update()
    {
        if(buttonHeldDown && power <= maxPower)
        {
            power += Time.deltaTime;
        }
        ChargeAttack();
    }

    public void HoldButton()
    {
        buttonHeldDown = true;
    }
    public void RealeseButton()
    {
        buttonHeldDown = false;
        power = 0;
    }

    public void BasicAttack()
    {
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClick = 0;
        }
        if (Time.time >= nextAttackTime)
        {
            if (rb.velocity.y == 0)
            {
                lastClickedTime = Time.time;
                noOfClick++;
                if (noOfClick == 1)
                {
                    anim.SetTrigger("Attack1");

                    Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                    foreach (Collider2D enemy in hitEnemy)
                    {
                        enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage);
                    }
                    nextAttackTime = Time.time + 1f / attackRate;
                    noOfClick = Mathf.Clamp(noOfClick, 0, 3);

                }
                else if (noOfClick == 2)
                {

                    anim.SetTrigger("Attack2");

                    Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                    foreach (Collider2D enemy in hitEnemy)
                    {
                        enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage);
                    }
                    nextAttackTime = Time.time + 1f / attackRate;
                    noOfClick = Mathf.Clamp(noOfClick, 0, 3);

                }
                else if (noOfClick == 3)
                {
                    anim.SetTrigger("Attack3");

                    Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                    foreach (Collider2D enemy in hitEnemy)
                    {
                        enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage);
                    }
                    nextAttackTime = Time.time + 1f / attackRate;
                    noOfClick = Mathf.Clamp(noOfClick, 0, 3);
                    noOfClick = 0;
                }

            }
        }
    }

    public void ChargeAttack()
    {
        
         
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
