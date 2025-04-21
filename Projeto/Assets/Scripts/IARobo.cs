using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class IARobo : MonoBehaviour
{
    // Variavel que indica a velocidade de rotacao do robo
    [SerializeField]
    private float rotationSpeed;

    // Variavel que pega a luz da area do tipo script "AtivarLuz"
    public AtivarLuz luzDaArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Rotacao do robo
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    // OnTriggerStay - Ele é chamado a cada frame enquanto algum objeto esta dentro do collider do robo
    private void OnTriggerStay(Collider other)
    {
        // Se a referencia da luz existe e ela estiver ligada
        if (luzDaArea != null && luzDaArea.LuzEstaLigada())
        {
            // Se a colisao for do objeto com a tag "Player"
            if (other.CompareTag("Player"))
            {
                Debug.Log("Robô viu o jogador com a luz acesa!");
            }
        }
    }
}