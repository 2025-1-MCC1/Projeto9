using System.Collections;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    // Objeto da tela de carregamento
    public GameObject loadingScreen;
    // Barra de carregamento (preenchimento visual)
    public Image loadingBarFill;

    // Fun��o p�blica para iniciar o carregamento da cena com base no ID
    public void LoadScene(int sceneId)
    {
        // Inicia a coroutine para carregar a cena de forma ass�ncrona
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    // Coroutine que realiza o carregamento da cena de forma ass�ncrona
    IEnumerator LoadSceneAsync(int sceneId)
    {
        // Inicia o carregamento da cena de forma ass�ncrona
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        // Ativa a tela de carregamento
        loadingScreen.SetActive(true);

        // Enquanto o carregamento n�o estiver completo
        while (!operation.isDone)
        {
            // Calcula o progresso (normalizando com base em 0.9f)
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            // Atualiza visualmente a barra de carregamento
            loadingBarFill.fillAmount = progressValue;

            // Espera o pr�ximo frame antes de continuar o loop
            yield return null;
        }
    }
}
