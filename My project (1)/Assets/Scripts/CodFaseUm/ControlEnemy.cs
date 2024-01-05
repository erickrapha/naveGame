using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    public Enemy inimigoPequeno;
    public Enemy inimigoGrande;

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
            Enemy prefabEnemy;
            float chance = Random.Range(0f, 100f);
            if (chance <= 10)
            {
                //10% de chance de criar o Enemy grande
                prefabEnemy = this.inimigoGrande;  
            }
            else
            {
                //90% de chance de criar o Enemy pequeno
                prefabEnemy = this.inimigoPequeno;
            }
            //Criar um Enemy novo
            Instantiate(prefabEnemy, posicaoEnemy, Quaternion.identity);
        }
    }
}
