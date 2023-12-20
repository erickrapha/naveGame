using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public float velocityMove;
    
    void Start()
    {
        Debug.Log("Iniciando script do Player");
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float velocityX = (horizontal * this.velocityMove);
        float velocityY = (vertical * this.velocityMove);

        this.body.velocity = new Vector2(velocityX, velocityY);
    }
}
