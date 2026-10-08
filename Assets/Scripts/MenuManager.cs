using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void PlayCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayCharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    public void GotoLevel(int level)
    {
        SceneManager.LoadScene($"Level{level}");
    }
    public void GoToLevelSelection()
    {
        SceneManager.LoadScene("SelectLevel");

    }

public void SelectCharacter(int characterIndex)
{
    PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
    PlayerPrefs.Save();
    SceneManager.LoadScene("Menu");

}
}
