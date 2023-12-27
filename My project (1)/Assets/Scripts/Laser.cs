using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D body2;
    public float velocityY;

    void Start()
    {
        this.body2.velocity = new Vector2(0, this.velocityY);
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            //Destr�i o Inimigo
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.Destruir();
            //Destr�i o Laser
            Destroy(this.gameObject);
        }
    }
}
