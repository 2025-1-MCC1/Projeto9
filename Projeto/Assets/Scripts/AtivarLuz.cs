using NUnit.Framework;
using UnityEngine;

public class AtivarLuz : MonoBehaviour
{
    // Variavel do tipo Luz
    public Light luz;
    // Variavel para determinar se a luz est· ligada ou n„o
    private ControleMapa controleMapa;

    private void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();
    }

    // Metodo que È utilizada em outro script para alterar a luz
    public void AlternarLuz()
    {
        // Muda o estado da variavel "ligada"
        controleMapa.luzLigada = !controleMapa.luzLigada;
        // Se a luz estiver acesa, a variavel ligada sera verdadeira
        luz.enabled = controleMapa.luzLigada;
<<<<<<< HEAD
       lightPercentage.TurnLight(true);
=======
>>>>>>> parent of 9bcc965 (continua√ß√£o de arrumar bugs)
    }

    // Metodo para verificar se a luz esta ligada
    public bool LuzEstaLigada()
    {
        // Se a referencia da luz existir e se a luz estiver ligada, ele retorna true
        return luz != null && luz.enabled;
    }
}
