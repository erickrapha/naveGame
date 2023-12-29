using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public float velocityMove;
    public Laser laserPrefab;
    public float tempoEsperaTiro;
    public Transform[] posicaoArma;

    private float intervaloTiro;
    private Transform armaAtual;
    private int vidas;
    private FimJogo telaFimJogo;
    
    void Start()
    {
        this.vidas = 5;
        this.intervaloTiro = 0;
        this.armaAtual = this.posicaoArma[0];
        ControladorPontuacao.Pontuacao = 0;
        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();
    }
    void Update()
    {
        this.intervaloTiro += Time.deltaTime;
        if (this.intervaloTiro >= this.tempoEsperaTiro)
        {
            this.intervaloTiro = 0;
            Atirar();
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float velocityX = (horizontal * this.velocityMove);
        float velocityY = (vertical * this.velocityMove);
        this.body.velocity = new Vector2(velocityX, velocityY);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Vida--;
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.ReceberDano();
        }
    }
    public int Vida
    {
        get { return this.vidas; }
        set 
        { 
            this.vidas = value; 
            if (this.vidas <= 0)
            {
                this.vidas = 0;
                this.gameObject.SetActive(false);
                //Exibir tela do Fim do Jogo
                telaFimJogo.Exibir();
            }
        }
    }
    private void Atirar()
    {
        Instantiate(this.laserPrefab, this.armaAtual.position, Quaternion.identity);
        if (this.armaAtual == this.posicaoArma[0])
        {
            this.armaAtual = this.posicaoArma[1];
        }
        else
        {
            this.armaAtual = this.posicaoArma[0];
        }
    }
}
