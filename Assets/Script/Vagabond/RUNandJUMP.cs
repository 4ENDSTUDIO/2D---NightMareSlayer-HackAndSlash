using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUNandJUMP : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    private Animator anim;


    private void Start()
    {
        extraJumps = extraJumpValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if(moveInput == 0)
        {
            anim.SetBool("Run", false);
        }else
        {
            anim.SetBool("Run", true);
        }

    }
    private void Update()
    {
        if(isGrounded == true)
        {
           
            extraJumps = extraJumpValue;
           

        }
        else
        {
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& extraJumps > 0)
        {
            anim.SetTrigger("TakeOf");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            anim.SetTrigger("TakeOf");
            rb.velocity = Vector2.up * jumpForce;
        }


        if(rb.velocity.y >  0)
        {
            anim.SetBool("Jump", true);

            
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("Fall", true);
            anim.SetBool("Jump", false);


        }
        if (rb.velocity.y == 0)
        {
         
            anim.SetBool("Fall", false);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
