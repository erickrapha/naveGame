using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Text textPontuacao;

    void Update()
    {
        this.textPontuacao.text = ControladorPontuacao.Pontuacao.ToString();
    }
}
