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
    public SpriteRenderer SpriteRenderer;

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
        VerificarLimite();
    }
    private void VerificarLimite()
    {
        Vector2 posicaoAtual  = this.transform.position;
        float metadeLargura = Largura/2f;
        float metadeAltura = Altura/2f;
        Camera cam = Camera.main;
        Vector2 limiteInferiorEsquerdo = cam.ViewportToWorldPoint(Vector2.zero); // (0, 0)
        Vector2 limiteSuperiorDireito = cam.ViewportToWorldPoint(Vector2.one); // (1, 1)
        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;
        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
        {
            //Saindo pela esquerda
            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);
        }
        else if (pontoReferenciaDireito > limiteSuperiorDireito.x)
        {
            //Saindo pela direita
            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);
        }
        posicaoAtual = this.transform.position;
        float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior = posicaoAtual.y - metadeAltura;
        if (pontoReferenciaSuperior > limiteSuperiorDireito.y)
        {
            //Saindo por cima
            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);
        }
        else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y)
        {
            //Saindo por baixo
            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);
        }
    }
    private float Largura
    {
        get 
        { 
            Bounds bounds = this.SpriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }
    private float Altura
    {
        get
        {
            Bounds bounds = this.SpriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.y;
        }
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
