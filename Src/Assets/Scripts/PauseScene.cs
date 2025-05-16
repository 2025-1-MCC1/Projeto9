using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public GameObject pauseUI;
    public bool pausarCena;
    private bool isPaused = false;

    void Update()
    {
        Pausar();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pressionou ESC");
            pausarCena = true;
            pauseUI.SetActive(true);
        }
    }

    public void Pausar()
    {
        isPaused = !isPaused;
        pauseUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
    }
    public void Continuar()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Sair()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2); 
    }
}

