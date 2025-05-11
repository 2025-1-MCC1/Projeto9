using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lightslider : MonoBehaviour
{
    private ControleMapa controleMapa;
    public Slider lightBar;

    public float timer = 5f;
    private float maxTime;

    public bool isRecharging;
    bool luzApagada;

    private Light luz;

    private void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
        luz = GetComponent<Light>();

        maxTime = timer;
        lightBar.maxValue = maxTime;
        lightBar.value = maxTime;

        luz.enabled = false; // começa apagada
    }

    private void Update()
    {
        EnableTimer();
    }

    void EnableTimer()
    {
        if (!isRecharging && luz.enabled)
        {
            // Gasta energia
            timer -= Time.deltaTime;

            if (timer <= 0.01f)
            {
                timer = 0f;
                isRecharging = true;
                luz.enabled = false; // só desliga a luz, NÃO o gerador
                controleMapa.luzLigada = false;
                luzApagada = true;
            }
        }
        else if (isRecharging && luzApagada)
        {
            // Recarregando
            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                timer = maxTime;
                isRecharging = false;
                luz.enabled = true;
                luzApagada = false;
            }
        }

        lightBar.value = timer;
    }
}
