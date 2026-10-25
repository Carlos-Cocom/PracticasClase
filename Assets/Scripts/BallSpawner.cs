using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [Header("Configuración de Spawner")]
    public GameObject ballPrefab; // Arrastra tu prefab aquí en el Inspector
    public int numberOfBalls = 10; // Cantidad de pelotas a generar

    [Header("Área de Generación (Límites)")]
    public Vector2 minSpawnPos = new Vector2(-2f, 6f); // Esquina inferior izquierda del área
    public Vector2 maxSpawnPos = new Vector2(2f, 8f);  // Esquina superior derecha del área

    void Start()
    {
        // Generar las pelotas al iniciar el juego
        for (int i = 0; i < numberOfBalls; i++)
        {
            SpawnRandomBall();
        }
    }

    void SpawnRandomBall()
    {
        // 1. Calcular una posición aleatoria dentro de los límites
        float randomX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float randomY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        // 2. Instanciar la pelota en la posición calculada
        GameObject newBall = Instantiate(ballPrefab, randomPosition, Quaternion.identity);

        // 3. Asignar un color aleatorio al SpriteRenderer
        SpriteRenderer ballRenderer = newBall.GetComponent<SpriteRenderer>();
        if (ballRenderer != null)
        {
            // Random.value devuelve un número entre 0.0 y 1.0 (formato RGB)
            Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
            ballRenderer.color = randomColor;
        }
    }
}