using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public void BackToMenu()
    {
        //Load the game scene (replace "GameScene" with the actual name of your game scene)
        SceneManager.LoadScene("Menu");
    }
}
