using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textPontuacao;
    public BarraVida barraVida;

    [SerializeField]
    private TelaPause telaPause;
    private Player jogador;

    private void Start()
    {
        this.telaPause.Desativar();
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        this.barraVida.ExibirVida(this.jogador.Vida);
        this.textPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
    }
    public void Pausar()
    {
        this.telaPause.Ativar();
    }
}
