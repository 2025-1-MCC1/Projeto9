using System.Collections;
using TMPro;
using UnityEngine;

public class DisapperingText : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public string personagem = "Czar";
    public string mensagemCompleta = "E vejo... quem parece ser...o chefe...";
    public float intervalo = 0.05f;
    public float tempoAntesDeDesaparecer = 10f;
    public float duracaoFadeOut = 1.5f;
    void Start() {
        
        mensagemCompleta = personagem + ": " + mensagemCompleta;
        StartCoroutine(DigitarTexto());// inicia a digitação d texto
    }

    IEnumerator DigitarTexto()
    {
        textoUI.text = ""; // Limpa o texto inicial
        foreach (char letra in mensagemCompleta)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(intervalo);
        }
    }
    IEnumerator DesaparecerTexto()
    {
        float tempo = 0;
        Color corInicial = textoUI.color;

        while (tempo < duracaoFadeOut)
        {
            float alpha = Mathf.Lerp(1, 0, tempo / duracaoFadeOut);
            textoUI.color = new Color(corInicial.r, corInicial.g, corInicial.b, alpha);
            tempo += Time.deltaTime;
            yield return null;
        }

        // Garante que ficou invisível no final
        textoUI.color = new Color(corInicial.r, corInicial.g, corInicial.b, 0);
    }
}

