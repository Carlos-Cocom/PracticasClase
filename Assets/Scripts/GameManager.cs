using UnityEngine;
using TMPro; // Necesario para controlar TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager instancia; // Patrón Singleton para acceder fácilmente desde otros scripts

    public int puntosP1 = 0;
    public int puntosP2 = 0;

    public TextMeshProUGUI textoP1;
    public TextMeshProUGUI textoP2;

    private bool juegoPausado = false;

    void Awake()
    {
        // Asegura que solo exista un GameManager en la escena
        if (instancia == null) instancia = this;
        else Destroy(gameObject);
    }

    public void AnotarGol(int idJugador)
    {
        if (idJugador == 1)
        {
            puntosP1++;
            textoP1.text = puntosP1.ToString();
        }
        else if (idJugador == 2)
        {
            puntosP2++;
            textoP2.text = puntosP2.ToString();
        }
    }

    public void AlternarPausa()
    {
        juegoPausado = !juegoPausado;

        if (juegoPausado)
        {
            Time.timeScale = 0f; // Congela las físicas y el movimiento
        }
        else
        {
            Time.timeScale = 1f; // Reanuda el tiempo a velocidad normal
        }
    }

    void Update()
    {
        // Permite pausar también usando la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AlternarPausa();
        }
    }

    public void HardResetPelota()
    {
        // Busca el script de la pelota en la escena
        VelocidadPelota pelota = FindObjectOfType<VelocidadPelota>();
        
        if (pelota != null)
        {
            // Elige aleatoriamente si la pelota sale a la izquierda (-1) o a la derecha (1)
            float direccionAleatoria = Random.Range(0, 2) == 0 ? -1f : 1f;
            
            // Llama a la función de la pelota para que regrese al centro con la nueva dirección
            pelota.ReiniciarPelota(direccionAleatoria);
            
            // Opcional: Si el juego estaba pausado, lo reanuda automáticamente
            if (Time.timeScale == 0f)
            {
                AlternarPausa();
            }
        }
    }
}