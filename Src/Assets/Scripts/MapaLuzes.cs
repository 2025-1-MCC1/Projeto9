using UnityEngine;

public class MapaLuzes : MonoBehaviour
{
    // Array de regioes do tipo AtivarLuz (outro script)
    public AtivarLuz[] regioes;

    // Metodo para mudar a luz da regiao
    public void AlternarLuzRegiao(int index)
    {
        // Ele pega o index da regiao e aplica o metodo AlternarLuz, criado no script "AtivarLuz"
        regioes[index].AlternarLuz();
    }
}
