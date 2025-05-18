using System.Collections;
using TMPro;
using UnityEngine;

public class DisapperingText : MonoBehaviour
{
    // Texto na tela usando TextMeshPro
    public TextMeshProUGUI textoUI;
    // Nome do personagem que vai falar
    public string personagem = "Czar";
    // Mensagem completa para mostrar na tela
    public string mensagemCompleta = "E vejo... quem parece ser...o chefe...";
    // Tempo entre cada letra aparecer
    public float intervalo = 0.05f;
    // Tempo antes do texto sumir (não usado aqui)
    public float tempoAntesDeDesaparecer = 10f;
    // Tempo que o texto leva para sumir com efeito de fade
    public float duracaoFadeOut = 1.5f;

    void Start()
    {
        // Junta o nome do personagem com a mensagem
        mensagemCompleta = personagem + ": " + mensagemCompleta;
        // Começa a digitar o texto letra por letra
        StartCoroutine(DigitarTexto());
    }

    // Escreve o texto devagar, letra por letra
    IEnumerator DigitarTexto()
    {
        // Começa com texto vazio
        textoUI.text = "";
        // Vai adicionando uma letra por vez, esperando um pouco
        foreach (char letra in mensagemCompleta)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(intervalo);
        }
    }

    // Faz o texto desaparecer devagar (fade out)
    IEnumerator DesaparecerTexto()
    {
        float tempo = 0;
        // Guarda a cor original do texto para modificar o alpha
        Color corInicial = textoUI.color;

        // Enquanto o tempo for menor que o tempo do fade
        while (tempo < duracaoFadeOut)
        {
            // Calcula o alpha do texto, de cheio (1) para transparente (0)
            float alpha = Mathf.Lerp(1, 0, tempo / duracaoFadeOut);
            // Aplica o alpha na cor do texto
            textoUI.color = new Color(corInicial.r, corInicial.g, corInicial.b, alpha);
            // Incrementa o tempo
            tempo += Time.deltaTime;
            yield return null;
        }

        // Garante que o texto fique invisível no final
        textoUI.color = new Color(corInicial.r, corInicial.g, corInicial.b, 0);
    }
}