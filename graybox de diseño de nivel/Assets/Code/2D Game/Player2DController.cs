using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    
    private float horizontal;
    [SerializeField] private float speedMovement;
    [SerializeField] private float jumpForce;
    private bool isFacingRight;

    [SerializeField] private BooleanVariable hasABomb;
    

    void Update()
    {
        rb.velocity = new Vector2(horizontal * speedMovement, rb.velocity.y);
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (!isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    public void Movement(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            Debug.Log("Salte");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (context.canceled && rb.velocity.y > 0f)
        {
            Debug.Log("ya no puedo Saltar");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && hasABomb)
        {
            Debug.Log("Lanzar bomba");
        }
        else if(context.performed && !hasABomb)
        {
            Debug.Log("No has encontrado la bomba");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bomb")
        {
            hasABomb.Value = true;
        }
    }
}
