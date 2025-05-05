using UnityEngine;
using UnityEngine.UI;

public class LightPercentage : MonoBehaviour
{
    public Slider lightBar; 
    public Light mainLight; 
    public bool luzLigada; 
    public float maxLightIntensity = 100; // int m�xima da luz
    private float currentLightIntensity = 0; // int atual da luz

    // mudan�a de valor do slider
    public void OnSliderValueChanged(float value)
    {
        if (luzLigada)
        {
            currentLightIntensity = value * maxLightIntensity; // ajusta a int com base no slider
            mainLight.intensity = currentLightIntensity;
            Debug.Log($"Intensidade da luz ajustada para: {currentLightIntensity}");
        }
    }

    void Start()
    {
        if (lightBar != null)
        {
            // add o evento para escutar mudan�as de valor no slider
            lightBar.onValueChanged.AddListener(OnSliderValueChanged);
            lightBar.value = 0; // para o slider come�ar no valor m�nimo
        }
        else
        {
            Debug.LogWarning("LightBar n�o foi atribu�do no Inspector!");
        }

        if (mainLight != null)
        {
            mainLight.intensity = 0; // garante que a luz comece apagada
        }
        else
        {
            Debug.LogError("Nenhuma luz foi atribu�da ao script!");
        }
    }

    void Update()
    {
        if (luzLigada)
        {
            // atualiza o valor do slider com base na intensidade atual
            lightBar.value = currentLightIntensity / maxLightIntensity;
        }
        else
        {
            // garante que a luz esteja apagada quando desligada
            currentLightIntensity = 0;
            mainLight.intensity = 0;
        }
    }

    // m�todo para ligar ou desligar a luz
    public void TurnLight(bool ligar)
    {
        luzLigada = ligar;

        if (ligar)
        {
            Debug.Log("Luz ligada.");
            currentLightIntensity = maxLightIntensity;
            mainLight.intensity = currentLightIntensity;
            lightBar.value = 100; // define o slider no valor m�ximo
        }
        else
        {
            Debug.Log("Luz desligada.");
            currentLightIntensity = 0;
            mainLight.intensity = 0;
            lightBar.value = 0; // define o slider no valor m�nimo
        }
    }
}
