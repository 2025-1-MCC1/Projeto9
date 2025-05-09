using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IARobo : MonoBehaviour
{
    // Variavel que indica a velocidade de rotacao do robo
    [SerializeField]
    private float rotationSpeed;

    // Variavel que pega a luz da area do tipo script "AtivarLuz"
    public AtivarLuz luzDaArea;

    public Transform targetObj;
    public float speedTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetObj = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotacao do robo
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }

    // OnTriggerStay - Ele é chamado a cada frame enquanto algum objeto esta dentro do collider do robo
    private void OnTriggerStay(Collider other)
    {
        // Se a referencia da luz existe e ela estiver ligada
        if (luzDaArea != null && luzDaArea.LuzEstaLigada())
        {
            // Se a colisao for do objeto com a tag "Player"
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Robo viu o jogador com a luz acesa");
                transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speedTarget * Time.deltaTime);
            }
        }
    }
}