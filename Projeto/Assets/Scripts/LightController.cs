using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light[] mainLight;
    ControleMapa controleMapa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();

        mainLight = GameObject.FindWithTag<>("mainLight");

            foreach (Light light in mainLight)
            {
                light.enabled = false; // Desativa a luz
            }    
    }

    // Update is called once per frame
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
