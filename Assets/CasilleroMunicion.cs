using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasilleroMunicion : MonoBehaviour
{
    public GameObject letra;
    public Animator anim;
    public bool dentro;
    public bool abierto;
    public float tiempo;
    public Contador contador;
    public bool tienemunicion;

    void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            contador = jugador.GetComponent<Contador>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador.");
        }
    }
    void Update()
    {
        if (dentro)
        {
            if (!abierto)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    anim.SetBool("Presionado", true);
                    abierto = true;

                }
            }

        }

        if (abierto)
        {
            letra.SetActive(false);
            tiempo += 1 * Time.deltaTime;
        }
        if (tiempo >= 1)
        {
            letra.SetActive(true);
            tiempo = 1;
            if (dentro)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!tienemunicion)
                    {
                        contador.contador++;
                        anim.SetBool("Lotiene", true);
                        contador.UpdateBotiquinText();
                        tienemunicion = true;
                        letra.SetActive(false);
                    }

                }
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            letra.SetActive(true);
            dentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Presionado", false);
            dentro = false;
            letra.SetActive(false);
        }
    }
}