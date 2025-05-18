using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IARobo : MonoBehaviour
{
    // Variavel que indica a velocidade de rotacao do robo
    [SerializeField]
    private float rotationSpeed;

    // Variavel que pega a luz da area do tipo script "AtivarLuz"
    public AtivarLuz luzDaArea;

    // Referencia ao script ControleMapa
    private ControleMapa controleMapa;

    // Transform do jogador (alvo)
    public Transform targetObj;
    // Velocidade ao seguir o alvo
    public float speedTarget;

    // Pontos de patrulha do robo
    public Transform[] patrolPoints;
    // Indice do ponto de patrulha atual
    public int targetPoint;
    // Velocidade da patrulha
    public float speed;

    // Variavel que define se o robo pode atacar
    public bool canAttack;

    void Start()
    {
        // Pega a referência do script ControleMapa
        controleMapa = FindAnyObjectByType<ControleMapa>();

        // Encontra o objeto com a tag "Player" e armazena seu transform
        targetObj = GameObject.FindGameObjectWithTag("Player").transform;

        // Inicializa o primeiro ponto de patrulha como 0
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Se o gerador estiver ligado
        if (controleMapa.geradorLigado)
        {
            // Executa patrulha do inimigo
            PatrulhaInimigo();
            // Define a tag do robo como "Robo"
            gameObject.tag = "Robo";
        }
        else
        {
            // Se o gerador estiver desligado, define a tag como "Door"
            gameObject.tag = "Door";
        }
    }

    // Metodo responsavel por movimentar o robo entre os pontos de patrulha
    void PatrulhaInimigo()
    {
        // Se o robo chegou ao ponto de patrulha atual
        if (transform.position == patrolPoints[targetPoint].position)
        {
            // Avança para o próximo ponto
            IncreaseTargetInt();
        }
        // Move o robo em direção ao ponto de patrulha atual
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    // Metodo que avança para o proximo ponto de patrulha
    void IncreaseTargetInt()
    {
        targetPoint++;
        // Se chegou ao fim do array, reinicia para o primeiro ponto
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    // Quando o robo colide com outro objeto
    private void OnCollisionEnter(Collision other)
    {
        // Se colidir com o jogador, muda para a cena 3
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
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
                // Move o robo em direção ao jogador
                transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speedTarget * Time.deltaTime);
            }
        }
    }
}