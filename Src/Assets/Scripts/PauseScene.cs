using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    // UI que representa o menu de pause
    public GameObject pauseUI;
    // Variavel que indica se a cena deve ser pausada
    public bool pausarCena;
    // Variavel que indica se o jogo est� pausado ou n�o
    private bool isPaused;

    private void Start()
    {
        // Desativa a UI de pause no in�cio
        pauseUI.SetActive(false);
    }

    void Update()
    {
        // Se o jogador apertar a tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Chama a fun��o Pausar
            Pausar();
            // Marca que a cena foi pausada
            pausarCena = true;
            // Ativa a UI de pause
            pauseUI.SetActive(true);
        }
    }

    // Fun��o que alterna o estado de pausa do jogo
    public void Pausar()
    {
        // Alterna entre pausado e n�o pausado
        isPaused = !isPaused;
        // Ativa ou desativa a UI de pause conforme o estado
        pauseUI.SetActive(isPaused);
        // Pausa ou retoma o tempo do jogo
        Time.timeScale = isPaused ? 0f : 1f;
    }

    // Fun��o para reiniciar a cena
    public void Reiniciar()
    {
        // Garante que o tempo volte ao normal
        Time.timeScale = 1f;
        // Recarrega a cena 2
        SceneManager.LoadScene(2);
    }

    // Fun��o para continuar o jogo sem pausar
    public void Continuar()
    {
        // Define o jogo como n�o pausado
        isPaused = false;
        // Esconde a UI de pause
        pauseUI.SetActive(false);
        // Retoma o tempo normal do jogo
        Time.timeScale = 1f;
    }

    // Fun��o para sair da cena atual e ir para a cena 2
    public void Sair()
    {
        // Retoma o tempo normal do jogo
        Time.timeScale = 1f;
        // Vai para a cena 2
        SceneManager.LoadScene(2);
    }
}

