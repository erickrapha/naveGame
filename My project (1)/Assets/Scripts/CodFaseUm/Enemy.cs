using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D body;
    public float velocityMinima;
    public float velocityMaxima;
    public int vidas;

    private float velocityY;

    void Start()
    {
        TryGetComponent(out spriteRenderer);
        Vector2 posicaoAtual = this.transform.position;
        float metadeLargura = Largura/2f;
        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;
        Camera cam = Camera.main;
        Vector2 limiteInferiorEsquerdo = cam.ViewportToWorldPoint(Vector2.zero); //(0, 0)
        Vector2 limiteSuperiorDireito = cam.ViewportToWorldPoint(Vector2.one); //(1, 1)
        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x)
        {
            //Enemy saiu pela esquerda
            float posicaoX = limiteInferiorEsquerdo.x + metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
        else if (pontoReferenciaDireito > limiteSuperiorDireito.x)
        {
            //Enemy saiu pela direita
            float posicaoX = limiteSuperiorDireito.x - metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y);
        }
        this.velocityY = Random.Range(this.velocityMinima, this.velocityMaxima);
    }
    void Update()
    {
        this.body.velocity = new Vector2(0, -this.velocityY);
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        if (posicaoNaCamera.y < 0)
        {
            //O Enemy saiu da área da Câmera!
            Player jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            jogador.Vida--;
            Destruir(false);
        }
    }
    public void ReceberDano()
    {
        this.vidas--;
        if (this.vidas <= 0)
        {
            ControlSound controlSound = GameObject.FindObjectOfType<ControlSound>();
            controlSound.TocarSomHitEnemy();
            Destruir(true);
        }
    }
    private float Largura
    {
        get 
        { 
            Bounds bounds = this.spriteRenderer.bounds;
            Vector2 tamanho = bounds.size;
            return tamanho.x;
        }
    }
    private void Destruir(bool derrotado)
    {
        if (derrotado)
        {
            ControladorPontuacao.Pontuacao++;
        }
        Destroy(this.gameObject);
        ControlSound controlSound = GameObject.FindObjectOfType<ControlSound>();
        controlSound.TocarSomDieEnemy();
    }
}
