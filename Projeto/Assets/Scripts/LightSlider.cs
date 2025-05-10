using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lightslider : MonoBehaviour
{
    [System.Serializable]
    public class LuzComSlider
    {
        public Light luz;
        public Slider slider;
        [HideInInspector] public Coroutine corrotina;
        [HideInInspector] public bool ligada = false;
    }

    public LuzComSlider[] luzesSliders;
    public float duracao = 10f;

    private ControleMapa controleMapa;

    void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    public void AlternarLuz(int indice)
    {
        if (indice < 0 || indice >= luzesSliders.Length) return;

        LuzComSlider item = luzesSliders[indice];

        if (item.ligada)
        {
            if (item.corrotina != null) StopCoroutine(item.corrotina);
            item.luz.enabled = false;
            item.slider.value = 0;
            item.ligada = false;
            item.corrotina = null;

            controleMapa.luzLigada = false; // Atualiza o controle do mapa
        }
        else
        {
            item.luz.enabled = true;
            item.ligada = true;
            item.corrotina = StartCoroutine(Temporizador(item));

            controleMapa.luzLigada = true; // Atualiza o controle do mapa
        }
    }

    IEnumerator Temporizador(LuzComSlider item)
    {
        float tempo = duracao;
        item.slider.maxValue = duracao;
        item.slider.value = duracao;

        while (tempo > 0)
        {
            tempo -= Time.deltaTime;
            item.slider.value = tempo;
            yield return null;
        }

        item.luz.enabled = false;
        item.slider.value = 0;
        item.ligada = false;
        item.corrotina = null;

        controleMapa.luzLigada = false; // Atualiza o controle do mapa
    }
}
