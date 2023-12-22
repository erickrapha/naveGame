using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D body;
    public float velocityMinima;
    public float velocityMaxima;

    private float velocityY;

    void Start()
    {
        this.velocityY = Random.Range(this.velocityMinima, this.velocityMaxima);
    }
    void Update()
    {
        this.body.velocity = new Vector2(0, -this.velocityY);
    }
}
