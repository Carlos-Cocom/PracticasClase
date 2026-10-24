using UnityEngine;

public class VelocidadPelota : MonoBehaviour
{
    public float velocidadInicial = 5f;
    public float velocidadMaxima = 15f; // Límite para evitar que atraviese paredes
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Inicia el movimiento hacia la derecha
        rb.linearVelocity = new Vector2(1f, 0f).normalized * velocidadInicial;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Limita la velocidad máxima para que no se acelere infinitamente
        if (rb.linearVelocity.magnitude > velocidadMaxima)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * velocidadMaxima;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Solo calcular el rebote diagonal si choca contra las plataformas
        if (collision.gameObject.CompareTag("Player"))
        {
            // --- CÓDIGO NUEVO: Cambio de color ---
            SpriteRenderer colorJugador = collision.gameObject.GetComponent<SpriteRenderer>();
            if (colorJugador != null)
            {
                // Copia el color de la plataforma que acaba de golpear
                spriteRenderer.color = colorJugador.color;
            }
            // ------------------------------------
            // Calcula la posición relativa del impacto (entre -1 y 1)
            float posicionYPelota = transform.position.y;
            float posicionYPlataforma = collision.transform.position.y;
            float alturaPlataforma = collision.collider.bounds.size.y;

            // 1 = borde superior, 0 = centro, -1 = borde inferior
            float diferenciaY = (posicionYPelota - posicionYPlataforma) / alturaPlataforma;

            // Determina si la plataforma está a la izquierda o derecha de la pelota
            float direccionX = (transform.position.x > collision.transform.position.x) ? 1f : -1f;

            // Crea el nuevo vector de dirección
            Vector2 nuevaDireccion = new Vector2(direccionX, diferenciaY).normalized;

            // Mantiene la velocidad que ya tenía la pelota, pero con la nueva dirección
            float velocidadActual = rb.linearVelocity.magnitude;
            
            // Opcional: Puedes sumar un poco de velocidad en cada golpe si quieres que el juego se vuelva más difícil
            // velocidadActual += 0.5f; 

            rb.linearVelocity = nuevaDireccion * velocidadActual;
        }
    }

    public void ReiniciarPelota(float direccionX)
    {
        // Regresa la pelota al centro de la pantalla
        transform.position = Vector2.zero; 

        // Detiene cualquier movimiento previo
        rb.linearVelocity = Vector2.zero; 

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white; 
        }

        // Aplica la nueva velocidad hacia la izquierda (-1) o derecha (1)
        rb.linearVelocity = new Vector2(direccionX, 0f).normalized * velocidadInicial;
    }
}