using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotaoContinua : MonoBehaviour
{
    public GameObject buttonObject; // arraste o botão aqui pelo Inspector
    public float delayInSeconds = 13f;

    void Start()
    {
        buttonObject.SetActive(false); // Garante que o botão comece invisível
        StartCoroutine(ShowButtonWithDelay());
    }
    IEnumerator ShowButtonWithDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        buttonObject.SetActive(true); // Ativa o botão após o tempo
    }
    public void Continue()
    { 
        SceneManager.LoadScene(2);// voltar para o menu
        
   }
}