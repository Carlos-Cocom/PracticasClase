using UnityEngine;

public class MovimientoR : MonoBehaviour
{
// Aumenté un poco la velocidad base porque AddForce suele necesitar valores más altos
    public float fuerza = 20f; 
    private Rigidbody2D rb;

    void Start()
    {
        // Obtener el componente Rigidbody2D que debe estar en el mismo objeto
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate es mejor que Update cuando se trabaja con físicas (Rigidbody)
    void FixedUpdate() 
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * fuerza);
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * fuerza);
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * fuerza);
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * fuerza);
        }
    }
}
