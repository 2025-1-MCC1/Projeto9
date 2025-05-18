using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControleMapa : MonoBehaviour
{
    // Objeto do tablet no jogo
    public GameObject tablet;
    // Imagem do mapa que aparece no tablet
    public Image map;
    // Fundo escuro que aparece com o mapa ativado
    public Image darkBg;

    // Indica se o jogador já pegou o tablet
    private bool comTablet;
    // Indica se o mapa está aberto ou fechado
    private bool mapaAberto;

    // Luzes que podem ser controladas
    public Light[] lights;

    // Indica se o jogador está perto do gerador
    private bool noGerador;

    // Estado da luz (ligada ou desligada)
    public bool luzLigada;

    // Estado do gerador (ligado ou desligado)
    public bool geradorLigado;

    // Porta principal do cenário
    public GameObject portaPrincipal;

    // Textos que aparecem na tela
    public TMP_Text[] texts;
    // Interface do tablet na tela
    public GameObject tabletUI;

    // Referência ao script que controla a movimentação do jogador
    private Movimentacao movimentacao;

    void Start()
    {
        // Busca o objeto Tablet na cena
        tablet = GameObject.Find("Tablet");
        // Esconde o tablet no começo
        tablet.gameObject.SetActive(false);

        // Esconde a interface do tablet no começo
        tabletUI.gameObject.SetActive(false);

        // Esconde o mapa e o fundo escuro no começo
        map.gameObject.SetActive(false);
        darkBg.gameObject.SetActive(false);

        // Pega o script de movimentação do jogador
        movimentacao = GetComponent<Movimentacao>();

        // Esconde todos os textos, menos o primeiro
        for (int i = 1; i < texts.Length; i++)
        {
            texts[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se deve abrir ou fechar o mapa
        AbrirTablet();

        // Se o jogador apertar E perto do gerador
        if (Input.GetKeyDown(KeyCode.E) && noGerador)
        {
            Debug.Log("Pressionou E");
            // Liga a luz e o gerador
            luzLigada = true;
            geradorLigado = true;
            // Abre a porta principal (desativa a porta)
            portaPrincipal.SetActive(false);
            // Mostra o tablet no mundo
            tablet.gameObject.SetActive(true);

            // Desativa os dois primeiros textos e limpa eles da array
            for (int i = 0; i < 2; i++)
            {
                texts[i].gameObject.SetActive(false);
                texts[i] = null;
            }

            // Ativa o terceiro texto
            texts[2].gameObject.SetActive(true);
        }

        // Se o jogador tiver ou estiver perto do cartão
        if (movimentacao.temCartao || movimentacao.estanoCartao)
        {
            // Esconde o texto do cartão
            texts[3].gameObject.SetActive(false);
        }
    }

    // Função que abre ou fecha o mapa quando o jogador aperta E
    void AbrirTablet()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Se tem o tablet e o mapa está fechado
            if (comTablet && !mapaAberto)
            {
                // Mostra o mapa e o fundo escuro
                map.gameObject.SetActive(true);
                darkBg.gameObject.SetActive(true);
                mapaAberto = true;
            }
            // Se o mapa está aberto
            else if (mapaAberto)
            {
                // Esconde o mapa e o fundo escuro
                map.gameObject.SetActive(false);
                darkBg.gameObject.SetActive(false);
                mapaAberto = false;
            }
        }
    }

    // Quando o jogador colide com algo
    private void OnTriggerEnter(Collider other)
    {
        // Se pegar o tablet
        if (other.CompareTag("Tablet"))
        {
            // Esconde o tablet no mundo e ativa o tablet na UI
            tablet.gameObject.SetActive(false);
            comTablet = true;
            tabletUI.gameObject.SetActive(true);
            // Atualiza textos para mostrar informações corretas
            texts[2].gameObject.SetActive(false);
            texts[3].gameObject.SetActive(true);
        }

        // Se chegar perto do gerador
        if (other.CompareTag("Gerador"))
        {
            noGerador = true;
            // Mostra texto para indicar que pode interagir com o gerador
            texts[1].gameObject.SetActive(true);
            texts[0].gameObject.SetActive(false);
        }
    }

    // Quando o jogador sai da área do gerador
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gerador"))
        {
            noGerador = false;
            // Esconde texto do gerador e mostra o texto inicial
            texts[1].gameObject.SetActive(false);
            texts[0].gameObject.SetActive(true);
        }
    }
}
