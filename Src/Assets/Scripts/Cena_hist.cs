using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class Cena_hist : MonoBehaviour
{
    public Animator anim1; // anima��o para pr�xima cena
    public Animator anim2; // anima��o para o menu
    public GameObject hist2Panel; // painel que aparece na pr�xima cena

    public void proxcena()
    {
        anim1.SetBool("ProximaCena", true); // ativa anima��o da pr�xima cena
        StartCoroutine(ProxCena()); // come�a espera antes de mostrar painel
    }

    public void Menu()
    {
        anim2.SetBool("ProximaCena", true); // ativa anima��o para o menu
        StartCoroutine(IrParaMenu()); // come�a espera antes de trocar cena
    }

    IEnumerator ProxCena()
    {
        yield return new WaitForSeconds(4); // espera 4 segundos
        hist2Panel.SetActive(true); // ativa painel da pr�xima cena
    }

    IEnumerator IrParaMenu()
    {
        yield return new WaitForSeconds(4); // espera 4 segundos
        SceneManager.LoadScene(1); // carrega cena do menu
    }
}
