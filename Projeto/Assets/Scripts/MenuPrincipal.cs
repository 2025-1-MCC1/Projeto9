using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOp��es;
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
    public void AbrirOp��es()
    {
        painelMenuInicial.SetActive(false);
        painelOp��es.SetActive(true);
    }
    public void FecharOp��es()
    {
        painelOp��es.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
