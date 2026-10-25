using UnityEngine;

public class MovimientoPDos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.up * fuerza);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.down * fuerza);
        }
    }
}
