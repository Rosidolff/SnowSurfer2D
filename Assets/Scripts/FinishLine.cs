using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f; // Retraso antes de recargar la escena
    [SerializeField] private ParticleSystem finishEffect; // Efecto de partículas al llegar a la meta
    void OnTriggerEnter2D(Collider2D other) // Se llama cuando otro collider entra en el trigger de este objeto
    {
        if (other.CompareTag("Player")) // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        {
            Debug.Log("Finish Line Reached!");
            //TODO: Implementar la lógica para finalizar el nivel o mostrar un mensaje de victoria
            finishEffect.Play(); // Reproduce el efecto de partículas al llegar a la meta
            Invoke(nameof(ReloadScene), reloadDelay); // Llama a la función ReloadScene después del retraso especificado
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual
    }
}
