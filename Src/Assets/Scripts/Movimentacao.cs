using TMPro;
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

    // Variavel que controla se o jogador esta agachado
    private bool estaAgachado;

    // Variavel que verifica se o jogador possui o cartao
    public bool temCartao;

    // Variavel que verifica se o jogador esta dentro do campo de colisao para pegar o cartao
    public bool estanoCartao;

    // Variavel que verifica se o jogador esta dentro do campo de colisao para inserir o cartao
    public bool estanoKeycard;

    // Variavel que referencia o objeto do cartao
    private GameObject card;

    // Variavel que referencia o script do script de controle de mapa
    private ControleMapa controleMapa;

    // Variavel que referencia os textos das missoes
    public TMP_Text[] texts;

    // Variavel que referencia as portas
    public Animator[] doorsAnim;

    // Variavel que verifica se a porta foi aberta
    public bool portaAberta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Referenciando a variavel "controller" ao character controller presente no objeto
        controller = GetComponent<CharacterController>();

        // Referenciando a variavel "controleMapa" ao script ControleMapa
        controleMapa = GetComponent<ControleMapa>();

        // Referenciando a camera principal da cena
        playerCamera = Camera.main.transform;

        // Referenciando o animator do objeto
        anim = GetComponent<Animator>();

        // Referenciando o objeto do cartao
        card = GameObject.Find("Card");

        // Deixando todos os textos desativados, com excessao do primeiro
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }
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

        if (estanoCartao && Input.GetKeyDown(KeyCode.F))
        {
            temCartao = true;
            Destroy(card);
            texts[0].gameObject.SetActive(false);
            texts[1].gameObject.SetActive(true);
        }

        // Verfica que, se o jogador possui o cartao, esta dentro do campo colisor do leitor de cartao e pressionar a tecla F
        if (temCartao && estanoKeycard && Input.GetKeyDown(KeyCode.F))
        {
            // A animacao das portas abrindo ira ativar
            for (int i = 0; i < doorsAnim.Length; i++)
            {
                doorsAnim[i].SetBool("Abrindo", true);
            }

            // A variavel "portaAberta" sera verdadeira
            portaAberta = true;
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
        // Verificando se o jogador esta dentro do campo colisor para pegar o cartao
        if (other.gameObject.CompareTag("Card"))
        {
            // Variavel "estanoCartao" sera verdadeira
            estanoCartao = true;
            // Texto com o indice 0 sera ativado
            texts[0].gameObject.SetActive(true);
        }

        // Verificando se o jogador esta dentro do campo colisor do leitor de cartao e se a variavel "geradorLigado"
        // do script "controleMapa" esta marcada como verdadeira
        if (other.gameObject.CompareTag("Keycard") && controleMapa.geradorLigado)
        {
            // Variavel "estanoKeycard" sera verdadeira
            estanoKeycard = true;
            // Texto com o indice 1 sera desativado
            texts[1].gameObject.SetActive(false);
            // Texto com o indice 2 sera ativado
            texts[2].gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificando se o jogador saiu do campo colisor para pegar o cartao
        if (other.gameObject.CompareTag("Card"))
        {
            // Variavel "estanoCartao" sera falsa
            estanoCartao = false;
            // Texto com o indice 0 sera desativado
            texts[0].gameObject.SetActive(false);
        }

        // Verificando se o jogador saiu do campo colisor do leitor de cartao e se a variavel "geradorLigado"
        // do script "controleMapa" esta marcada como verdadeira
        if (other.gameObject.CompareTag("Keycard") && controleMapa.geradorLigado)
        {
            // Variavel "estanoKeycard" sera falsa
            estanoKeycard = false;
            // Texto com o indice 1 sera ativado
            texts[1].gameObject.SetActive(true);
            // Texto com o indice 2 sera desativado
            texts[2].gameObject.SetActive(false);
        }
    }
}
