using NUnit.Framework;
using UnityEngine;

public class AtivarLuz : MonoBehaviour
{
    // Variavel do tipo Luz
    public Light luz;
    // Variavel para determinar se a luz est� ligada ou n�o
    private bool ligada = true;

    // Metodo que � utilizada em outro script para alterar a luz
    public void AlternarLuz()
    {
        // Muda o estado da variavel "ligada"
        ligada = !ligada;
        // Se a luz estiver acesa, a variavel ligada sera verdadeira
        luz.enabled = ligada;
    }

    // Metodo para verificar se a luz esta ligada
    public bool LuzEstaLigada()
    {
        // Se a referencia da luz existir e se a luz estiver ligada, ele retorna true
        return luz != null && luz.enabled;
    }
}
