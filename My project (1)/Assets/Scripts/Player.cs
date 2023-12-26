using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D body;
    public float velocityMove;
    public Laser laserPrefab;
    public float tempoEsperaTiro;

    private float intervaloTiro;
    
    void Start()
    {
        this.intervaloTiro = 0;
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
    private void Atirar()
    {
        Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
}
