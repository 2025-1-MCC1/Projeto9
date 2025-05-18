using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Refer�ncia ao painel do menu inicial (definido pelo Inspector)
    [SerializeField] private GameObject painelMenuInicial;
    // Refer�ncia ao painel de op��es (definido pelo Inspector)
    [SerializeField] private GameObject painelOp��es;

    // Fun��o para abrir o painel de op��es e esconder o menu inicial
    public void AbrirOp��es()
    {
        painelMenuInicial.SetActive(false);
        painelOp��es.SetActive(true);
    }

    // Fun��o para fechar o painel de op��es e voltar para o menu inicial
    public void FecharOp��es()
    {
        painelOp��es.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    // Fun��o para sair do jogo (s� funciona em build)
    // Exibe mensagem no console para testes no editor
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

}
