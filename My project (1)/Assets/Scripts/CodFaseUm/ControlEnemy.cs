using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public Enemy inimigoOriginal;

    private float tempoDecorrido;
    
    void Start()
    {
        this.tempoDecorrido = 0;
    }
    void Update()
    {
        this.tempoDecorrido += Time.deltaTime;
        if (this.tempoDecorrido >= 1.0f)
        {
            this.tempoDecorrido = 0;
            Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);
            Vector2 posicaoEnemy = new Vector2(posicaoX, posicaoMaxima.y);
            //Criar um Enemy novo
            Instantiate(this.inimigoOriginal, posicaoEnemy, Quaternion.identity);

        }
    }
}
