using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    Rigidbody2D rb;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
       horizontalMove= Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    public void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false,jump);
        jump = false;
    }

}
