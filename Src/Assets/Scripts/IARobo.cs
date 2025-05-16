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

    private ControleMapa controleMapa;

    public Transform targetObj;
    public float speedTarget;

    // Patrulheiro
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;

    public bool canAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controleMapa = FindAnyObjectByType<ControleMapa>();

        targetObj = GameObject.FindGameObjectWithTag("Player").transform;

        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (controleMapa.geradorLigado)
        {
            PatrulhaInimigo();
            gameObject.tag = "Robo";
        }
        else
        {
            gameObject.tag = "Door";
        }
    }

    void PatrulhaInimigo()
    {
        if (transform.position == patrolPoints[targetPoint].position)
        {
            IncreaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void IncreaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
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
                transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speedTarget * Time.deltaTime);
            }
        }
    }
}