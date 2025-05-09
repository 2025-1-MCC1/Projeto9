using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void RestartGame()
    {
        // Reinicia o jogo
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
