using UnityEngine;
using UnityEngine.UI;

public class AtivarLuz : MonoBehaviour
{
    // Referência ao controle de mapa externo
    private ControleMapa controleMapa;

    // Referência ao script do slider de luz ambiente
    public LightSlider slider;

    // Array de luzes com a tag "mainLight"
    public Light[] mainLight;

    // Intensidade máxima da luz
    public float maxLightIntensity = 100f;

    // Intensidade atual da luz
    public float currentLightIntensity = 0f;

    public Slider lightSlider;

    void Start()
    {
        // Encontra o script ControleMapa na cena
        controleMapa = FindAnyObjectByType<ControleMapa>();

        // Encontra todos os objetos com a tag "mainLight" e pega seus componentes Light
        GameObject[] luzes = GameObject.FindGameObjectsWithTag("mainLight");
        mainLight = new Light[luzes.Length];
        for (int i = 0; i < luzes.Length; i++)
        {
            mainLight[i] = luzes[i].GetComponent<Light>();
        }
    }

    // Alterna o estado da luz (ligar/desligar)
    public void AlternarLuz()
    {
        // Inverte o estado da luz no controle
        controleMapa.luzLigada = !controleMapa.luzLigada;

        // Define intensidade e slider de acordo com o novo estado
        currentLightIntensity = controleMapa.luzLigada ? maxLightIntensity : 0f;

        foreach (Light luz in mainLight)
        {
            if (luz != null)
            {
                luz.intensity = currentLightIntensity;
                luz.enabled = controleMapa.luzLigada;
            }
        }

        /*// Atualiza o slider (se houver)
        if (slider != null && slider.lightSlider != null)
        {
            slider.lightSlider.value = controleMapa.luzLigada ? 1f : 0f;
        }*/

        Debug.Log("Luz " + (controleMapa.luzLigada ? "ligada." : "desligada."));
    }

    // Verifica se qualquer luz do array está ligada
    public bool LuzEstaLigada()
    {
        foreach (Light luz in mainLight)
        {
            if (luz != null && luz.enabled)
            {
                return true;
            }
        }
        return false;
    }
}

