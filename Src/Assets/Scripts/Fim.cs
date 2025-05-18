using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Fim : MonoBehaviour
{
    // Refer�ncia ao script que controla o movimento do jogador
    private Movimentacao movimentacao;

    // Imagem que escurece a tela quando a porta est� aberta
    public Image darkUI;

    void Start()
    {
        // Procura o script de movimenta��o na cena
        movimentacao = FindAnyObjectByType<Movimentacao>();

        // Come�a com a tela escura desligada
        darkUI.gameObject.SetActive(false);
    }

    void Update()
    {
        // Se a porta estiver aberta
        if (movimentacao.portaAberta)
        {
            // Liga a tela escura
            darkUI.gameObject.SetActive(true);

            // Come�a a esperar para trocar de cena
            StartCoroutine(NextScene());
        }
    }

    // Espera um tempo e depois muda para outra cena
    IEnumerator NextScene()
    {
        // Espera 5 segundos
        yield return new WaitForSeconds(5);
        // Troca para a cena n�mero 4
        SceneManager.LoadScene(4);
    }
}
