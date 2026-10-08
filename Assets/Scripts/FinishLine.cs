using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float reloadDelay = 1f; // Retraso antes de recargar la escena
    [SerializeField] private ParticleSystem finishEffect; // Efecto de partículas al llegar a la meta
    void OnTriggerEnter2D(Collider2D other) // Se llama cuando otro collider entra en el trigger de este objeto
    {
        if (other.CompareTag("Player"))
{
    Debug.Log("Player has crossed the finish line!");
    finishEffect.Play();
    Invoke(nameof(NextLevel), reloadDelay);
}
    }

void NextLevel()
{
    int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
    PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
    PlayerPrefs.Save();
    if (unlockedLevel >=6)
        {
            SceneManager.LoadScene("Menu");
        }
    else
        {
    SceneManager.LoadScene($"level{unlockedLevel+1}");
        }
}

}
