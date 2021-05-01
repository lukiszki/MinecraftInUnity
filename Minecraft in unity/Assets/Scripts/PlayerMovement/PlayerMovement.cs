using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls controls;

    private float x, y=0;
    
    
    private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private float jumpHeight = 3f;
    
    private Vector3 velocity;

[SerializeField]private Transform groundCheck;
[SerializeField]private float groundDistance; 
[SerializeField]private LayerMask groundMask;

    private bool isGrounded;
    void Awake()
    {
        controls = new PlayerControls();
        controller = GetComponent<CharacterController>();
        
        //Position
        controls.Gameplay.MoveForward.performed += ctx => y = ctx.ReadValue<float>();
        controls.Gameplay.MoveForward.canceled += ctx => y = 0f;
        controls.Gameplay.MoveBack.performed += ctx => y = -ctx.ReadValue<float>();
        controls.Gameplay.MoveBack.canceled += ctx => y = 0f;

        controls.Gameplay.MoveLeft.performed += ctx => x = -ctx.ReadValue<float>();
        controls.Gameplay.MoveLeft.canceled += ctx => x = 0f;
        controls.Gameplay.MoveRight.performed += ctx => x = ctx.ReadValue<float>();
        controls.Gameplay.MoveRight.canceled += ctx => x = 0f;
        
        controls.Gameplay.Jump.performed += ctx => Jump();
        
        
    }

    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            
        }

      
      //  float x = Input.GetAxis("Horizontal");
      //  float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move*speed*Time.deltaTime);


       /* if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }*/

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    void Jump()
    {
        if(isGrounded)
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
