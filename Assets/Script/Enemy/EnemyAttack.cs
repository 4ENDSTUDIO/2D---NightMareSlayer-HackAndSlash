﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Die");
        anim.SetBool("IsDead", true);
        //GetComponent<Collider2D>().enabled = false;
        gameObject.layer = LayerMask.NameToLayer("Default");
        this.enabled = false;
        Destroy(gameObject, 1.5f);




    }
   
}
