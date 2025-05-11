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
        if (controleMapa == null)
        {
            Debug.LogWarning("ControleMapa não encontrado na cena.");
        }
    }

    public void AlternarLuz(int indice)
    {
        if (indice < 0 || indice >= luzesSliders.Length) return;

        LuzComSlider item = luzesSliders[indice];

        if (item.ligada)
        {
            DesligarLuz(item);
        }
        else
        {
            // Desliga todas as outras luzes, se alguma estiver ligada
            foreach (var luzItem in luzesSliders)
            {
                if (luzItem.ligada)
                {
                    DesligarLuz(luzItem);
                }
            }

            item.luz.enabled = true;
            item.ligada = true;
            item.corrotina = StartCoroutine(Temporizador(item));

            if (controleMapa != null)
                controleMapa.luzLigada = true; // Atualiza o controle do mapa
        }
    }

    private void DesligarLuz(LuzComSlider item)
    {
        if (item.corrotina != null) StopCoroutine(item.corrotina);
        item.luz.enabled = false;
        item.slider.value = 0;
        item.ligada = false;
        item.corrotina = null;

        if (controleMapa != null)
            controleMapa.luzLigada = false;
    }

    IEnumerator Temporizador(LuzComSlider item)
    {
        float tempo = duracao;
        item.slider.maxValue = duracao;
        item.slider.value = duracao;

        while (tempo > 0)
        {
            tempo = Mathf.Max(tempo - Time.deltaTime, 0);
            item.slider.value = tempo;
            yield return null;
        }

        DesligarLuz(item);
    }
}
