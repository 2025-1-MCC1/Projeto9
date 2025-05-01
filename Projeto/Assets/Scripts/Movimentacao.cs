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

    // Variavel do animator do personagem
    private Animator anim;

    // Variavel que controla se o jogador esta agachado ou nao
    private bool estaAgachado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Referenciando a variavel "controller" ao character controller presente no objeto
        controller = GetComponent<CharacterController>();
        // Referenciando a camera principal da cena
        playerCamera = Camera.main.transform;
        anim = GetComponent<Animator>();
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
        
        // Ativando a animacao de andar do personagem
        anim.SetBool("estaAndando", movimento != Vector3.zero);

        // Invocando o metodo "Agachar"
        Agachar();

        // Verificando as animacoes
        if (movimento != Vector3.zero && estaAgachado)
        {
            anim.SetBool("estaAndandoAgachado", true);
            anim.SetBool("estaAndando", false);
            anim.SetBool("estaAgachado", false);
        }
        else if (movimento == Vector3.zero && estaAgachado)
        {
            anim.SetBool("estaAndandoAgachado", false);
            anim.SetBool("estaAgachado", true);
        }

        else if (movimento != Vector3.zero && estaAgachado && Input.GetKeyDown(KeyCode.C))
        {
            anim.SetBool("estaAgachado", false);
            anim.SetBool("estaAndando", true);
        }
    }

    void Agachar()
    {
        // Se o jogador apertar a tecla "C", ele agacha
        if (Input.GetKeyDown(KeyCode.C))
        {
            estaAgachado = !estaAgachado;
            anim.SetBool("estaAgachado", estaAgachado);
            anim.SetBool("estaAndando", false);
        }

        // Se o jogador apertar a tecla "C" novamente, ele deixa de ficar agachado
        if (Input.GetKeyDown(KeyCode.C) && estaAgachado)
        {
            anim.SetBool("estaAgachado", false);
            anim.SetBool("estaParado", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door") && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Entrou na porta");
        }
    }
}
