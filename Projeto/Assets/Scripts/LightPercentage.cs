using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class LightPercentage : MonoBehaviour
{
    public Slider lightBar; 
    public Light mainLight; 
    public bool luzLigada;
    public GameObject Spotlight;     
    public float maxLightIntensity = 100f; // int m�xima da luz
    public float currentLightIntensity = 0f; // int atual da luz

    // M�todo chamado quando o valor do slider muda
    public void OnSliderValueChanged(float value)
    {
        if (luzLigada)
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
            // add o evento para escutar mudan�as de valor no slider
            lightBar.onValueChanged.AddListener(OnSliderValueChanged);
            lightBar.value = 0; // para q o slider comece no valor m�nimo
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
        if (Spotlight == null) // Verifica se a refer�ncia n�o foi atribu�da no Inspector
        {
            Spotlight = GameObject.Find("Spotlight"); 
        }
         
        /*void Update()
        {
            if (luzLigada)
            {
                // att o valor do slider com base na intensidade atual
                lightBar.value = currentLightIntensity / maxLightIntensity;
            }
            else
            {
                // garante q a luz esteja apagada quando desligada
                currentLightIntensity = 0;
                mainLight.intensity = 0;
            }
        }*/
    }

    // liga ou desliga a luz
    public void TurnLight(bool ligar)
    {
        luzLigada = ligar;

        if (ligar)
        {
            Debug.Log("Luz ligada.");
            currentLightIntensity = maxLightIntensity;
            mainLight.intensity = currentLightIntensity;
            lightBar.value = 1; // define o slider no valor m�ximo
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
