using UnityEngine;
using UnityEngine.SceneManagement;


public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float CrashDelay = 1f; // Tiempo de retraso antes de reiniciar la escena
    [SerializeField] private ParticleSystem CrashEffect;
    PlayerController playerController; // Referencia al PlayerController para deshabilitar el control del jugador
  void Start()
  {
        playerController = FindAnyObjectByType<PlayerController>(); // Encuentra el PlayerController en la escena
    }



  void OnTriggerEnter2D(Collider2D other) // Se llama cuando otro collider entra en el trigger de este objeto
  {
      int layerIndex = LayerMask.NameToLayer("Floor"); // Obtiene el índice de la capa "Floor"
      if (other.gameObject.layer == layerIndex) // Verifica si el objeto que colisiona está en la capa "Floor"
      {
        Debug.Log("Player Crashed!");
          //TODO: Implementar la lógica para reiniciar el nivel o mostrar un mensaje de derrota
        playerController.CanControlPlayer = false; // Deshabilita el control del jugador
        CrashEffect.Play(); // Reproduce el efecto de partículas al llegar a la meta
        Invoke(nameof(ReloadScene), CrashDelay);
      }
  }
      void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual
    }
}
