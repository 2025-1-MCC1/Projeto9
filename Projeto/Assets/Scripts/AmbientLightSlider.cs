using UnityEngine;
using UnityEngine.UI;

public class AmbientLightSlider : MonoBehaviour
{
    public Slider lightSlider;

    void Start()
    {
        if (lightSlider == null)
        {
            Debug.LogError("Slider de luz ambiente n�o est� atribu�do!");
        }
    }

    void Update()
    {
        // Obt�m a intensidade m�dia da cor ambiente (RGB convertidos para intensidade)
        float intensity = RenderSettings.ambientLight.grayscale;

        // Atualiza o valor do slider (supondo que o valor m�ximo seja 1)
        if (lightSlider != null)
        {
            lightSlider.value = intensity;
        }
    }
}

