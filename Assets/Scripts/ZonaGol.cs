using UnityEngine;

public class ZonaGol : MonoBehaviour
{
    [Tooltip("Usa 1 para sacar hacia la derecha y -1 para sacar hacia la izquierda")]
    public float direccionSaque = 1f;

    [Tooltip("Escribe 1 si esta zona suma puntos al Jugador 1, o 2 si suma al Jugador 2")]
    public int jugadorQueAnota = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        VelocidadPelota pelota = collision.GetComponent<VelocidadPelota>();
        
        if (pelota != null)
        {
            // Suma un punto al jugador correspondiente
            GameManager.instancia.AnotarGol(jugadorQueAnota);

            // Reinicia la pelota
            pelota.ReiniciarPelota(direccionSaque);
        }
    }
}