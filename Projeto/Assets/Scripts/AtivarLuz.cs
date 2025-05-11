using UnityEngine;

public class AtivarLuz : MonoBehaviour
{
    // Referência ao controle de mapa externo
    private ControleMapa controleMapa;

    private Lightslider lightSlider;

    // Array de luzes com a tag "mainLight"
    public Light[] lights;

    void Start()
    {
        lightSlider = GetComponent<Lightslider>();

        // Encontra o script ControleMapa na cena
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Alterna o estado de todas as luzes
    public void AlternarLuz()
    {
        foreach (Light luz in lights)
        {
            if (luz != null && !lightSlider.isRecharging)
            {
                // Inverte o estado da luz
                luz.enabled = !luz.enabled;

                // Alterna o controle da luz no mapa
                controleMapa.luzLigada = luz.enabled;
            }
            else if (lightSlider.isRecharging)
            {
                luz.enabled = false;
                controleMapa.luzLigada = false;
            }
        }
    }

    // Verifica se qualquer luz do array está ligada
    public bool LuzEstaLigada()
    {
        foreach (Light luz in lights)
        {
            if (luz != null && luz.enabled)
            {
                return true;
            }
        }
        return false;
    }
}

