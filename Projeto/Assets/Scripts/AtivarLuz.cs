using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;


public class AtivarLuz : MonoBehaviour
{
    // Variavel do tipo Luz
    public Light luz;
    // Variavel para determinar se a luz est� ligada ou n�o
    private ControleMapa controleMapa;
    public LightPercentage lightPercentage;

   void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Metodo que � utilizada em outro script para alterar a luz
    public void AlternarLuz()
    {
        // Muda o estado da variavel "ligada"
        controleMapa.luzLigada = !controleMapa.luzLigada;
        // Se a luz estiver acesa, a variavel ligada sera verdadeira
        luz.enabled = controleMapa.luzLigada;

        lightPercentage.TurnLight(controleMapa.luzLigada);
    }

    // Metodo para verificar se a luz esta ligada
    public bool LuzEstaLigada()
    {
        // Se a referencia da luz existir e se a luz estiver ligada, ele retorna true
        return luz != null && luz.enabled;
    }
}
