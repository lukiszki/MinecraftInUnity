using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private PlayerControls Controls;

    private float mouseX=0;
    private float mouseY;

    private Vector2 move;
    
    [SerializeField]
    private float mouseSensitivity = 100f;
    private Transform playerBody;

    private float xRotation = 0f;
    void Awake()
    {
        Controls = new PlayerControls();
        playerBody = transform.parent.transform;
        Cursor.lockState = CursorLockMode.Locked;
        
        //Camera controls
        /*Controls.Gameplay.ViewUp.performed += ctx => mouseY = ctx.ReadValue<float>()* mouseSensitivity * Time.deltaTime;    
        Controls.Gameplay.ViewUp.canceled += ctx => mouseY = 0f;
        
        Controls.Gameplay.ViewDown.performed += ctx => mouseY = -(ctx.ReadValue<float>()* mouseSensitivity * Time.deltaTime);    
        Controls.Gameplay.ViewDown.canceled += ctx => mouseY = 0f;
        
        Controls.Gameplay.ViewLeft.performed += ctx => mouseX = -(ctx.ReadValue<float>()* mouseSensitivity * Time.deltaTime);    
        Controls.Gameplay.ViewLeft.canceled += ctx => mouseX = 0f;
        
        Controls.Gameplay.ViewRight.performed += ctx => mouseX = ctx.ReadValue<float>()* mouseSensitivity * Time.deltaTime;    
        Controls.Gameplay.ViewRight.canceled += ctx => mouseX = 0f;*/
        Controls.Gameplay.View.performed +=
            ctx =>  move = ctx.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {

         mouseX = move.x  * mouseSensitivity * Time.deltaTime;
         mouseY = move.y * mouseSensitivity * Time.deltaTime;
        

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
    private void OnEnable()
    {
        Controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        Controls.Gameplay.Disable();
    }
}
