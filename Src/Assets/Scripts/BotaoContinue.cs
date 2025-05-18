using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotaoContinua : MonoBehaviour
{
    // Objeto do botão a ser exibido (arrastado via Inspector)
    public GameObject buttonObject;
    // Objeto que representa o botão ou elemento para voltar ao menu
    public GameObject voltaraoMenu;
    // Tempo de atraso em segundos antes de mostrar os botões
    public float delayInSeconds = 13f;

    void Start()
    {
        // Garante que o botão comece invisível
        buttonObject.SetActive(false);
        // Garante que o botão de voltar ao menu também comece invisível
        voltaraoMenu.SetActive(false);
        // Inicia a coroutine que exibirá os botões após o tempo definido
        StartCoroutine(ShowButtonWithDelay());
    }

    // Coroutine que espera um tempo antes de ativar os botões
    IEnumerator ShowButtonWithDelay()
    {
        // Espera o tempo definido em segundos
        yield return new WaitForSeconds(delayInSeconds);
        // Ativa o botão principal
        buttonObject.SetActive(true);
        // Ativa o botão de voltar ao menu
        voltaraoMenu.SetActive(true);
    }

    // Função chamada ao clicar no botão de continuar
    public void Continue()
    {
        // Carrega a cena de índice 1 (menu)
        SceneManager.LoadScene(1);
    }
}