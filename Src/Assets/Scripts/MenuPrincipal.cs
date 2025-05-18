using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Referência ao painel do menu inicial (definido pelo Inspector)
    [SerializeField] private GameObject painelMenuInicial;
    // Referência ao painel de opções (definido pelo Inspector)
    [SerializeField] private GameObject painelOpções;

    // Função para abrir o painel de opções e esconder o menu inicial
    public void AbrirOpções()
    {
        painelMenuInicial.SetActive(false);
        painelOpções.SetActive(true);
    }

    // Função para fechar o painel de opções e voltar para o menu inicial
    public void FecharOpções()
    {
        painelOpções.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    // Função para sair do jogo (só funciona em build)
    // Exibe mensagem no console para testes no editor
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
