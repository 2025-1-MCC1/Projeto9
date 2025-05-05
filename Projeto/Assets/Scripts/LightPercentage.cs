using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class LightPercentage : MonoBehaviour
{
    public Slider lightBar; // Changed UnityEngine.UIElements.Slider to UnityEngine.UI.Slider
    public Light[] lights;
    public Light light;
    public bool luzLigada;
    public float maxLightIntensity = 100; // intensidade m�xima da luz
    private float LightIntensity = 0;

    public void OnSliderValueChanged(float value) // valor do slider
    {
        Debug.Log("Valor do Slider: " + value);
    }

    void Start()
    {
        if (lightBar != null)
        {
            // Adiciona o evento para escutar mudan�as de valor
            lightBar.onValueChanged.AddListener(OnSliderValueChanged); // UnityEngine.UI.Slider supports onValueChanged
        }
        else
        {
            Debug.LogWarning("LightBar n�o atribu�do no Inspector!"); // checa se o slider foi atribu�do
        }
    }

    void Update()
    {
        if (luzLigada) // verifica a a��o da luz
        {
            LightIntensity -= Time.deltaTime;
            lightBar.value = LightIntensity;
            light.intensity = LightIntensity;
        }
        else
        {
            light.intensity = 0;
        }
    }

    public void TurnLight(bool l) // ligar e desligar a luz pelo slider
    {
        Debug.Log("Ligou a luz");
        LightIntensity = maxLightIntensity;
        luzLigada = l;
    }
}
