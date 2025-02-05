﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public float dirX, moveSpeed;
    public float Jump;
    bool Hurt, Dead;
    bool facingRight = true;
    Vector3 localScale;
   
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !Dead && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * Jump);
        //if (Input.GetKey(KeyCode.LeftShift))
        //    moveSpeed = 10f;
        //else
        //    moveSpeed = 5f;
        setAnimationState();
        if (!Dead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {
        if (!Hurt)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        checkWhereToFace();
    }

    void setAnimationState()
    {
        if(Input.GetKey(KeyCode.R))
        {
            anim.SetBool("Attack_3", true);
        }
        else
        {
            anim.SetBool("Attack_3", false);
        }
        if(dirX == 0)
        {
            anim.SetBool("Run", false);
            
        }
        if(rb.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
        if(Mathf.Abs(dirX) == moveSpeed && rb.velocity.y == 0)
        {
            anim.SetBool("Run", true);
        }
        if(Input.GetKey(KeyCode.DownArrow)&& Mathf.Abs(dirX)==moveSpeed)
        {
            anim.SetBool("Dash", true);
        }
        else
        {
            anim.SetBool("Dash", false);
        }
        if(rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", true);
        }
    }

    void checkWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.name.Equals("Fire")&& HealthBar.health > 0)
        {
            anim.SetTrigger("Hurt");

        }
        else
        {
            dirX = 0;
            Dead = true;
            anim.SetTrigger("Die");
        }
    }
}
