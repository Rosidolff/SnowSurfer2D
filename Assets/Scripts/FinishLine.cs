using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) // Se llama cuando otro collider entra en el trigger de este objeto
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        {
            Debug.Log("Finish Line Reached!");
            //TODO: Implementar la lógica para finalizar el nivel o mostrar un mensaje de victoria
        }
    }
}
