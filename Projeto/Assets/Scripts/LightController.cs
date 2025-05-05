using UnityEngine;

public class LightController : MonoBehaviour
{
    Light[] lights;
    ControleMapa controleMapa;

    void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();

        lights = FindObjectsOfType<Light>();

            foreach (Light light in lights)
            {
                light.enabled = false; // Desativa a luz
            }    
    }

    void Update()
    {
        if (controleMapa.luzLigada)
        {
            foreach (Light light in lights)
            {
                light.enabled = true; // Ativa a luz
            }
        }
    }
}
