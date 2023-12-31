using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimJogo : MonoBehaviour
{
    public Text textPontuacao;
    public Text textMelhorPontuacao;

    public void Exibir()
    {
        this.gameObject.SetActive(true);
        this.textPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
        this.textMelhorPontuacao.text = ControladorPontuacao.MelhorPontuacao.ToString();
        //Pausar o jogo
        Time.timeScale = 0;
    }
    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }
    public void Recomecar()
    {
        //Despausar o jogo
        Time.timeScale = 1;
        SceneManager.LoadScene("Fase1");
    }
}
