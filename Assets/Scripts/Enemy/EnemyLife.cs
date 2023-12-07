using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int health = 100;
    public float pushForce = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            health -= 25;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Vector2 pushDirection = (other.gameObject.transform.position - transform.position).normalized;

            // Encontrar el Rigidbody del jugador
            Rigidbody2D playerRigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                // Aplicar fuerza al jugador en la dirección opuesta al enemigo
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
    //si colisiona con el compate tag "Player" ,destruir al player
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Player")) 
        {
            Destroy(col.gameObject);
            Application.LoadLevel("Derrota"); 
        }
    }
}