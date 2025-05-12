using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpções;
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
    public void AbrirOpções()
    {
        painelMenuInicial.SetActive(false);
        painelOpções.SetActive(true);
    }
    public void FecharOpções()
    {
        painelOpções.SetActive(false);
        painelMenuInicial.SetActive(true);
    }
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
