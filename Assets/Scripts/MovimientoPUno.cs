using UnityEngine;

public class MovimientoPUno : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float movimiento = Input.GetAxisRaw("Vertical");

        transform.Translate(
            Vector3.up * movimiento * velocidad * Time.deltaTime
        );
    }
}
