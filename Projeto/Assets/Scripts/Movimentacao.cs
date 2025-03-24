using Unity.VisualScripting;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    // Criando uma variavel para referenciar o character controller do objeto
    private CharacterController controller;
    // Variavel para referenciar a camera
    private Transform playerCamera;
    [SerializeField]
    // Variavel para velocidade do objeto
    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Referenciando a variavel "controller" ao character controller presente no objeto
        controller = GetComponent<CharacterController>();
        // Referenciando a camera principal da cena
        playerCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Anexando os inputs dos eixos horizontal e vertical em suas devidas variaveis
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Criando uma variavel vector 3 de movimento, anexando o vector 3 dos eixos em x e z
        Vector3 movimento = new Vector3(horizontal, 0, vertical);
        // Fazer com que o vetor transforme as direcoes do personagem de acordo com a camera do jogo
        movimento = playerCamera.TransformDirection(movimento);
        movimento.y = 0;

        // Utilizando a funcao de move de um character controller para controlar a movimentacao
        controller.Move(movimento * Time.deltaTime * speed);
        // Gravidade do personagem
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);

        if (movimento != Vector3.zero)
        {
            // Fazendo a rotacao do personagem de forma suavizada
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movimento), Time.deltaTime * 10);
        }        
    }
}
