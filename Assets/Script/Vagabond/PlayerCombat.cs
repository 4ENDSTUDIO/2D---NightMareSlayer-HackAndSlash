using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float power = 0;
    float minPower = 0;
    float maxPower = 3;
    bool buttonHeldDown;
    public Image barChargeAttack;
    float lerpSpeed;

    [Header("JumpAttack")]
    public float force = 10f;
    public RUNandJUMP yo;
   


    private void Update()
    {
        
        ChargeAttackBar();
    }
   

    public void HoldButton()
    {
        
        
        buttonHeldDown = true;
        
    }
    public void RealeseButton()
    {
        if(power > 2.5)
        {
            anim.SetTrigger("ChargeAttack");

            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<EnemyAttack>().TakeDamage(attackDamage * 3);
            }
            power = 0;
        }
     

        if (power < 3)
        {
            buttonHeldDown = false;
            power = 0;

        }
        if (minPower > 3)
        {
           
            minPower = 0;
        }

        if (minPower < 3)
        {
            buttonHeldDown = false;
            minPower = 0;
           

        }



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

    public void JumpAttack()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClick = 0;
        }
        if (Time.time >= nextAttackTime)
        {
            if (rb.velocity.y != 0)
            {
                lastClickedTime = Time.time;
                noOfClick++;
                if (noOfClick == 1)
                {
                    anim.SetTrigger("JumpAttack1");

                    rb.velocity = Vector2.up * force;
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

                    anim.SetTrigger("JumpAttack2");
                    rb.velocity = Vector2.up * force;
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
                    anim.SetTrigger("JumpAttack3");
                    rb.velocity = Vector2.down * force;
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

    public void ChargeAttackBar()
    {
        if (buttonHeldDown && minPower <= maxPower )
        {
            minPower += Time.fixedDeltaTime;
            


        }
        if (minPower > 1 && power <= maxPower)
        {

            power += Time.fixedDeltaTime;
            

        }
        if(power > 1.1)
        {
            anim.SetBool("ChargePower1", true);
        }
        else
        {
            anim.SetBool("ChargePower1", false);
        }
        lerpSpeed = 3.3f * Time.deltaTime;

        barChargeAttack.gameObject.SetActive(true);
        barChargeAttack.fillAmount = Mathf.Lerp(barChargeAttack.fillAmount, power / maxPower, lerpSpeed);

        Color healthColor = Color.Lerp(Color.green, Color.red, (power / maxPower));
        barChargeAttack.color = healthColor;

    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
