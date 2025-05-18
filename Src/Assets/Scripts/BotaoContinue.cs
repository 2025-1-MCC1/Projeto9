using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotaoContinua : MonoBehaviour
{
    // Objeto do bot�o a ser exibido (arrastado via Inspector)
    public GameObject buttonObject;
    // Objeto que representa o bot�o ou elemento para voltar ao menu
    public GameObject voltaraoMenu;
    // Tempo de atraso em segundos antes de mostrar os bot�es
    public float delayInSeconds = 13f;

    void Start()
    {
        // Garante que o bot�o comece invis�vel
        buttonObject.SetActive(false);
        // Garante que o bot�o de voltar ao menu tamb�m comece invis�vel
        voltaraoMenu.SetActive(false);
        // Inicia a coroutine que exibir� os bot�es ap�s o tempo definido
        StartCoroutine(ShowButtonWithDelay());
    }

    // Coroutine que espera um tempo antes de ativar os bot�es
    IEnumerator ShowButtonWithDelay()
    {
        // Espera o tempo definido em segundos
        yield return new WaitForSeconds(delayInSeconds);
        // Ativa o bot�o principal
        buttonObject.SetActive(true);
        // Ativa o bot�o de voltar ao menu
        voltaraoMenu.SetActive(true);
    }

    // Fun��o chamada ao clicar no bot�o de continuar
    public void Continue()
    {
        // Carrega a cena de �ndice 1 (menu)
        SceneManager.LoadScene(1);
    }
}