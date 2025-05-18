using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Cena_hist : MonoBehaviour
{
    public Animator anim1; // animação para próxima cena
    public Animator anim2; // animação para o menu
    public GameObject hist2Panel; // painel que aparece na próxima cena

    public void proxcena()
    {
        anim1.SetBool("ProximaCena", true); // ativa animação da próxima cena
        StartCoroutine(ProxCena()); // começa espera antes de mostrar painel
    }

    public void Menu()
    {
        anim2.SetBool("ProximaCena", true); // ativa animação para o menu
        StartCoroutine(IrParaMenu()); // começa espera antes de trocar cena
    }

    IEnumerator ProxCena()
    {
        yield return new WaitForSeconds(4); // espera 4 segundos
        hist2Panel.SetActive(true); // ativa painel da próxima cena
    }

    IEnumerator IrParaMenu()
    {
        yield return new WaitForSeconds(4); // espera 4 segundos
        SceneManager.LoadScene(1); // carrega cena do menu
    }
}
