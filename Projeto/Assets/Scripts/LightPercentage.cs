using UnityEngine;
using UnityEngine.UI;

public class LightPercentage : MonoBehaviour
{
    public Slider lightBar;
    public Light mainLight;
    public ControleMapa controleMapa;
    public float maxLightIntensity = 15f; // int máxima da luz
    public float currentLightIntensity = 0f; // int atual da luz

    private void Awake()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Método chamado quando o valor do slider muda
    public void OnSliderValueChanged(float value)
    {
        if (controleMapa.luzLigada)
        {
            currentLightIntensity = value * maxLightIntensity; // ajusta a intensidade com base no slider
            mainLight.intensity = currentLightIntensity;
            Debug.Log($"Intensidade da luz ajustada para: {currentLightIntensity}");
        }
    }

    void Start()
    {
        if (lightBar != null)
        {
            // add o evento para escutar mudanças de valor no slider
            lightBar.onValueChanged.AddListener(OnSliderValueChanged);
            lightBar.value = 0; // para q o slider comece no valor mínimo
        }

        if (mainLight != null)
        {
            mainLight.intensity = 0; // garante que a luz comece apagada
        }
        
    }

    void Update()
    {
        if (controleMapa.luzLigada)
        {
            // att o valor do slider com base na intensidade atual
            lightBar.value = currentLightIntensity / maxLightIntensity;
        }
        else
        {
            // garante q a luz esteja apagada quando desligada
            currentLightIntensity = 0;
            //mainLight.intensity = 0;
        }
    }

    // método para ligar ou desligar a luz
  public void TurnLight(bool ligar)
    {
        controleMapa.luzLigada = ligar;

        if (ligar)
        {
            Debug.Log("Luz ligada.");
            
            currentLightIntensity = maxLightIntensity;
            mainLight.intensity = currentLightIntensity;
            lightBar.value = 1; // define o slider no valor máximo
        }
        else
        {
            Debug.Log("Luz desligada.");
            currentLightIntensity = 0;
            //mainLight.intensity = 0;
            lightBar.value = 0; // define o slider no valor mínimo
        }
    }
}
