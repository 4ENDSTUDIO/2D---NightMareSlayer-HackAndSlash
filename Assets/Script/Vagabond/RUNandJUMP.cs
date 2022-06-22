using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUNandJUMP : MonoBehaviour
{
    [Header("Player Basic")]
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;

    [Header("Condition Jump")]
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    [Header("Application Double Jump")]
    private int extraJumps;
    public int extraJumpValue;

    public Joystick Joystik;
    float horizontalMove = 0f;
    private Animator anim;

    [Header("Smoke")]
    public GameObject dustJump;
    public ParticleSystem DustRun;

    [Header("Sound Effect")]
    private AudioSource source;
    public AudioClip JumpSound;
  
    

    private void Start()
    {
        source = GetComponent<AudioSource>();
       
        extraJumps = extraJumpValue;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        moveInput = Joystik.Horizontal * speed;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (Joystik.Horizontal >= .5f)
        {
            horizontalMove = moveInput;
        }
        else if (Joystik.Horizontal <= -.5f)
        {
            horizontalMove = -moveInput;
        }
        else
        {
            horizontalMove = 0f;
        }

        anim.SetFloat("Speed", Mathf.Abs(moveInput));


        if (facingRight == false && moveInput > 0)
        {
            
            Flip();
            CreateDustRun();
        } else if (facingRight == true && moveInput < 0)
        {
           
            Flip();
            CreateDustRun();
        }
        
     

        if (moveInput == 0)
        {

            anim.SetBool("Run", false);
        }else
        {
            
            anim.SetBool("Run", true);
        }

    }
    private void Update()
    {
        if (isGrounded == true)
        {

            
            extraJumps = extraJumpValue;


        }
        else
        {
            anim.SetBool("Jump", true);
        }

      
        
      

     


        if(rb.velocity.y >  0)
        {
            DustRun.Stop();
            anim.SetBool("Jump", true);
            



        }
        if (rb.velocity.y < 0 )
        {

            DustRun.Stop();
            anim.SetBool("Fall", true);
            anim.SetBool("Jump", false);
           


        }
        if (rb.velocity.y == 0)
        {
         
            anim.SetBool("Fall", false);
        }

    }
    public void jump()
    {
        if (extraJumps > 0)
        {
            CreateDustRun();
            Instantiate(dustJump, transform.position, Quaternion.identity);
            source.clip = JumpSound;
            source.Play();
            anim.SetTrigger("TakeOf");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (extraJumps == 0 && isGrounded == true)
        {

            CreateDustRun();
            anim.SetTrigger("TakeOf");
            rb.velocity = Vector2.up * jumpForce;

        }
    }

  

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        Vector3 Scaler1 = DustRun.transform.localScale;
        Scaler1.x *= -1;
        DustRun.transform.localScale = Scaler;
        DustRun.Play();
    }

    public void CreateDustRun()
    {
        



    }

 
}
