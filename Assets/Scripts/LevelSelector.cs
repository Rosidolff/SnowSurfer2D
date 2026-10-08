using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    void Start()
{
    int unLockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

    Transform levels = transform.GetChild(0);

    for (int i = 0; i < levels.childCount; i++)
    {
        Button levelButton = levels.GetChild(i).GetComponent<Button>();
        levelButton.interactable = (i <unLockedLevel);
    }
}

}
