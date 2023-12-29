using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textPontuacao;
    public BarraVida barraVida;

    private Player jogador;

    private void Start()
    {
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        this.barraVida.ExibirVida(this.jogador.Vida);
        this.textPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
    }
}
