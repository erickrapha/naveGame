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
        Vector2 posicaoAtual = this.transform.position;
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
    }
}
