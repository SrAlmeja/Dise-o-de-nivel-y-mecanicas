using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerMC : MonoBehaviour
{
    public float speed = 5f; // Velocidad del jugador
    public float jumpForce = 10f; // Fuerza del salto del jugador
    public float fallMultiplier = 2.5f; // Multiplicador de velocidad de caída
    public float lowJumpMultiplier = 2f; // Multiplicador de velocidad de caída suave
    public Transform groundCheck; // Objeto que comprueba si el jugador está en el suelo
    public LayerMask groundLayer; // Capa del suelo

    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform bulletSpawn; // Punto de spawn del proyectil
    public float bulletSpeed = 10f; // Velocidad del proyectil

    private Rigidbody2D rb; // Rigidbody del jugador
    private bool isGrounded; // Indica si el jugador está en el suelo
    private bool canJump = true; // Indica si el jugador puede saltar

    [SerializeField] bool UnlockedBomb;

    public string SceneToLoad;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            canJump = true;
        }
        else
        {
            // Si el jugador está en el aire, aplica la velocidad de caída
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        if (canJump && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            canJump = false;
        }

        if (UnlockedBomb)
        {
            Shoot();    
        }
        
            if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        // Cambiar la escala del objeto del jugador y sus hijos en función de la dirección del movimiento
        transform.localScale = new Vector3(moveInput < 0 ? -1 : 1, 1, 1);
    }
    
    private void Shoot()
    {
        if(UnlockedBomb && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }
        
    }


    // Función para aumentar o disminuir la velocidad de caída del jugador
    public void SetFallMultiplier(float value)
    {
        fallMultiplier = value;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            SceneManager.LoadSceneAsync(SceneToLoad);
        }
        if (col.tag == "BombUpdate")
        {
            UnlockedBomb = true;
        }
    }
    
    
}