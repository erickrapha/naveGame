using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D body2;
    public float velocityY;

    void Start()
    {
        ControlSound controlSound = GameObject.FindObjectOfType<ControlSound>();
        controlSound.TocarSomLaser();
        this.body2.linearVelocity = new Vector2(0, this.velocityY);
    }
    private void Update()
    {
        Camera cam = Camera.main;
        Vector3 posicaoNaCamera = cam.WorldToViewportPoint(this.transform.position);
        //Saiu da tela pela parte superior
        if (posicaoNaCamera.y > 1)
        {
            //Destr�i o Laser
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            //Destr�i o Inimigo
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.ReceberDano();
            //Destr�i o Laser
            Destroy(this.gameObject);
        }
    }
}
