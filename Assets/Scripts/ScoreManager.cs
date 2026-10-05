using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText; // Variable para almacenar la puntuación del jugador

    public void AddScore(int score)
    {
        scoreText.text = score.ToString(("00000")); // Actualiza el texto de la puntuación en la interfaz de usuario}
}
}