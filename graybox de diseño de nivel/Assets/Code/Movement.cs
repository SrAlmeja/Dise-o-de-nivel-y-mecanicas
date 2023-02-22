using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
    public float speed = 5.0f;  // velocidad del personaje
    public float jumpHeight = 2.0f;  // altura del salto
    private Rigidbody rb;  // componente Rigidbody del personaje
    
    void Start() {
        rb = GetComponent<Rigidbody>();  // obtener el componente Rigidbody del personaje
    }
    
    void Update() {
        // movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
        // salto
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2.0f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }
}

