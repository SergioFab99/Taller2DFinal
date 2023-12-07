using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidadPersecucion = 5.0f;
    private Transform jugador;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Comprobar si el jugador aún existe
        if (jugador != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = jugador.position - transform.position;
            direccion.Normalize();

            // Mueve el enemigo en la dirección del jugador // Soy Giacomo
            transform.Translate(direccion * velocidadPersecucion * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            //quitar 1 de vida
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // Si colisiona con el jugador, destruye el jugador
            Destroy(collision.gameObject); // Destruye al jugador
        }
    }
}

