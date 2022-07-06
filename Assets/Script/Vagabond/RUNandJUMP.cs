using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RUNandJUMP : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody2D rb;
    private float movementInputDirection;
    public float movementSpeed = 10.0f;
    private bool isFacingRight = true;



    [Header("Animation")]
    private bool isRun;




    [Header("Condition Jump")]
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;
    private bool canJump;


    [Header("Application Double Jump")]
    private int extraJumps;
    public int extraJumpValue;


    [Header("Enviroment")]
    public Joystick Joystik;
    private Animator anim;
    


    [Header("Smoke")]
    public GameObject dustJump;
    public ParticleSystem DustRun;


    [Header("Sound Effect")]
    private AudioSource source;
    public AudioClip JumpSound;

    [Header("Script Call")]
    public PlayerCombat basicAttack;


   
  
    

    private void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
    }
    private void Update()
    {
        UpdateAnimation();
        checkMovementDirection();
        CheckInput();
        checkIfJump();
       
      

     

    }
    private void FixedUpdate()
    {
        ApplyMovement();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
    }
    void checkIfJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        else
        {
            anim.SetBool("Jump", true);
        }
        if (rb.velocity.y > 0)
        {
            DustRun.Stop();
            anim.SetBool("Jump", true);
        }
        if (rb.velocity.y < 0)
        {
            DustRun.Stop();
            anim.SetBool("Fall", true);
            anim.SetBool("Jump", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("Fall", false);
           
        }

        
        if (isGrounded && rb.velocity.y == 0)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }
    

    private void UpdateAnimation()
    {
        anim.SetBool("Run", isRun);
    }
    private void checkMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
        if(rb.velocity.x !=0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        DustRun.Play();
    }
    private void CheckInput()
    {
       
        movementInputDirection = Joystik.Horizontal;
    }

    private void ApplyMovement()
    {
       
            rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
        
            
        
        
       
     
    }

  

  
    public void jump()
    {
        if (extraJumps > 0)
        {

            Instantiate(dustJump, transform.position, Quaternion.identity);
            source.clip = JumpSound;
            source.Play();
            anim.SetTrigger("TakeOf");
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if (canJump)
        {
            if (extraJumps > 0 )
            {

                Instantiate(dustJump, transform.position, Quaternion.identity);
                source.clip = JumpSound;
                source.Play();
                anim.SetTrigger("TakeOf");
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (extraJumps == 0 && isGrounded == true)
            {


                anim.SetTrigger("TakeOf");
                rb.velocity = Vector2.up * jumpForce;

            }
        }
       
    }

  

    //void Flip()
    //{
    //    facingRight = !facingRight;
    //    Vector3 Scaler = transform.localScale;
    //    Scaler.x *= -1;
    //    transform.localScale = Scaler;

    //    Vector3 Scaler1 = DustRun.transform.localScale;
    //    Scaler1.x *= -1;
    //    DustRun.transform.localScale = Scaler;
    //    DustRun.Play();
    //}
}
