using UnityEngine;

public class AtivarLuz : MonoBehaviour
{
    // Refer�ncia ao controle de mapa externo
    private ControleMapa controleMapa;

    // Array de luzes com a tag "mainLight"
    public Light[] lights;

    // A luz que esta regi�o controla (deve ser configurado no Inspector)
    public int indiceDaLuz;

    void Start()
    {
        // Encontra o script ControleMapa na cena
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Alterna o estado de uma luz espec�fica
    public void AlternarLuz()
    {
        // Verifica se o �ndice est� dentro do limite do array de luzes
        if (indiceDaLuz >= 0 && indiceDaLuz < lights.Length)
        {
            Light luz = lights[indiceDaLuz];

            // Inverte o estado da luz individualmente
            luz.enabled = !luz.enabled;

            // Alterna o controle da luz no mapa
            controleMapa.luzLigada = luz.enabled;

            Debug.Log("Luz " + (luz.enabled ? "ligada." : "desligada.") + " (�ndice: " + indiceDaLuz + ")");
        }
        else
        {
            Debug.LogError("�ndice da luz fora do limite do array de luzes.");
        }
    }

    // Verifica se qualquer luz do array est� ligada
    public bool LuzEstaLigada()
    {
        foreach (Light luz in lights)
        {
            if (luz != null && luz.enabled)
            {
                return true;
            }
        }
        return false;
    }
}

