using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class LightPercentage : MonoBehaviour
{ 
    public Slider lightBar;
    public Light[] lights;
    public Light light;
    public bool luzLigada;
    public float maxLightIntensity = 100;
    private float LightIntensity = 100;
    void Start()
    {
        
    }

    void Update()
    {
        if (luzLigada)
        {
            
            LightIntensity -= Time.deltaTime;
            lightBar.value = LightIntensity;
            light.intensity = LightIntensity;
        }
       

    }

    public void TurnLight(bool l)
    {
        Debug.Log("Ligou a luz");
        LightIntensity = maxLightIntensity;
        luzLigada = l;
    }
}
