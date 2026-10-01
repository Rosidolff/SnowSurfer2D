using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem CrashEffect;
  void OnTriggerEnter2D(Collider2D other) // Se llama cuando otro collider entra en el trigger de este objeto
  {
      int layerIndex = LayerMask.NameToLayer("Floor"); // Obtiene el índice de la capa "Floor"
      if (other.gameObject.layer == layerIndex) // Verifica si el objeto que colisiona está en la capa "Floor"
      {
        Debug.Log("Player Crashed!");
          //TODO: Implementar la lógica para reiniciar el nivel o mostrar un mensaje de derrota
        CrashEffect.Play(); // Reproduce el efecto de partículas al llegar a la meta
        Invoke(nameof(ReloadScene), 1f);
      }
  }
      void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); // Recarga la escena actual
    }
}
