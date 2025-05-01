using UnityEngine;
using UnityEngine.UI;

public class LightBar: MonoBehaviour
{
    public Slider lightBar;
    public Transform sensorPoint; 
    public float maxLightIntensity = 1.0f; 

    void Update()
    {
        float lightLevel = GetLightLevel();
        lightBar.value = Mathf.Clamp01(lightLevel);
    }

    float GetLightLevel()
    {
        Vector3 point = sensorPoint.position;

        Vector3[] directions = {
            Vector3.up, Vector3.down, Vector3.forward, Vector3.back, Vector3.left, Vector3.right
        };

        float totalLight = 0f;
        foreach (var dir in directions)
        {
            if (Physics.Raycast(point, dir, out RaycastHit hit, 5f))
            {
                Light light = hit.collider.GetComponent<Light>();
                if (light != null)
                {
                    totalLight += light.intensity;
                }
            }
        }

        
        totalLight += RenderSettings.ambientIntensity;

        return totalLight / maxLightIntensity;
    }
}


