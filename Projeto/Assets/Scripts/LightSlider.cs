 using UnityEngine;
using System.Collections;

public class Lightslider : MonoBehaviour
{
    public Light luz; 
    public float duracao = 5f; 

    void Start()
    {
        // Inicia a corrotina para controlar o tempo da luz
        StartCoroutine(AtivarLuzTemporariamente());
    }

    IEnumerator AtivarLuzTemporariamente()
    {
        luz.enabled = true; // Liga a luz
        yield return new WaitForSeconds(10); // Espera pelo tempo definido
        luz.enabled = false; // Desliga a luz
    }
}
