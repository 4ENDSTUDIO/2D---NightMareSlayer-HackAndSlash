using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    Rigidbody2D rb;
    public Joystick Joystick;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
       if(Joystick.Horizontal >= .5f)
        {
            horizontalMove = runSpeed;
        }else if(Joystick.Horizontal <= -.5f)
        {
            horizontalMove = -runSpeed; 
        }else
        {
            horizontalMove = 0f;
        }
       
        animator.SetFloat("Speed", Mathf.Abs( horizontalMove)); 
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    public void Landing()
    {
        animator.SetBool("IsJumping", false);
        
    }
    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }

}
