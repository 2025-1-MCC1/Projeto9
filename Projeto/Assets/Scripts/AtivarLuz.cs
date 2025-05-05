using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class AtivarLuz : MonoBehaviour
{
    // Variavel do tipo Luz
    public Light luz;
    // Variavel para determinar se a luz está ligada ou não
    private ControleMapa controleMapa;

    public Slider lightBar;
    public LightPercentage lightPercentage;

    private void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Metodo que é utilizada em outro script para alterar a luz
    public void AlternarLuz()
    {
        // Muda o estado da variavel "ligada"
        controleMapa.luzLigada = !controleMapa.luzLigada;
        // Se a luz estiver acesa, a variavel ligada sera verdadeira
        luz.enabled = controleMapa.luzLigada;
       lightPercentage.TurnLight(true);
    }

    // Metodo para verificar se a luz esta ligada
    public bool LuzEstaLigada()
    {
        // Se a referencia da luz existir e se a luz estiver ligada, ele retorna true
        return luz != null && luz.enabled;
    }
}
