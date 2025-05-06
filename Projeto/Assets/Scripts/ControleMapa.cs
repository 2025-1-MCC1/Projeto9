using UnityEngine;
using UnityEngine.UI;

public class ControleMapa : MonoBehaviour
{
    // Variavel do tipo GameObject, para referenciar o tablet
    public GameObject tablet;
    // Variavel do tipo Image, para referenciar o mapa
    public Image map;
    // Variavel do tipo Image, para referenciar o fundo mais escuro quando o mapa estiver ativado
    public Image darkBg;

    // Variavel que determina se o jogador esta com o tablet ou nao
    private bool comTablet;
    // Variavel que determina se o jogador esta com o mapa aberto ou nao
    private bool mapaAberto;

    public Light[] lights;

    private bool noGerador;

    public bool luzLigada;

    public GameObject portaPrincipal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Referenciando o tablet
        tablet = GameObject.Find("Tablet");
        tablet.gameObject.SetActive(false);

        // Deixando os objetos não ativos
        map.gameObject.SetActive(false);
        darkBg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Chamando o metodo "AbrirTablet"
        AbrirTablet();

        if (Input.GetKeyDown(KeyCode.E) && noGerador)
        {
            Debug.Log("Pressionou E");
            luzLigada = true;
            portaPrincipal.SetActive(false);
            tablet.gameObject.SetActive(true);
        }
    }

    void AbrirTablet()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (comTablet && !mapaAberto)
            {
                map.gameObject.SetActive(true);
                darkBg.gameObject.SetActive(true);
                mapaAberto = true;
            }
            else if (mapaAberto)
            {
                map.gameObject.SetActive(false);
                darkBg.gameObject.SetActive(false);
                mapaAberto = false;

            }
            else
            {

            }
        }
    }

    // Se o jogador entrar em colisao com o tablet, o tablet some e a variavel "comTablet" fica verdadeira
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tablet"))
        {
            tablet.gameObject.SetActive(false);
            comTablet = true;
        }

        if (other.CompareTag("Gerador"))
        {
            noGerador = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gerador"))
        {
            noGerador = false;
        }
    }
}
