using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float bounciness = 0.5f; // Bounciness o rebote del proyectil
    public float gravityScale = 1f; // Escala de gravedad del proyectil
    public float drag = 0.5f; // Arrastre o desaceleración del proyectil
    public LayerMask wallLayer; // Capa de los muros

    private Rigidbody2D rb; // Rigidbody del proyectil
    private Vector2 direction; // Dirección del movimiento del proyectil

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = transform.right; // Establece la dirección del movimiento hacia la derecha (puede cambiar según la orientación del objeto)

        // Establece la escala de gravedad y el arrastre del proyectil
        rb.gravityScale = gravityScale;
        rb.drag = drag;
        rb.velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * (speed-drag);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.GetContact(0).normal;
        direction = Vector2.Reflect(direction, normal) * bounciness;
        Destroy(gameObject, 5.0f);
    }
}