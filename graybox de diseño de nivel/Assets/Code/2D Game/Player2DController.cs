using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float horizontal;
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    private bool isGrounded;
    private bool isFacingRight;
    
// Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        Movement();
        //Jump
        if (isGrounded)
        {
            Jump();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void Movement()
    {
        
    }

    void Jump()
    {
        
    }
}
