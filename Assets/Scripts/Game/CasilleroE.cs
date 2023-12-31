using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasilleroE : MonoBehaviour
{
    public GameObject letra;
    public Animator anim;
    public bool dentro;
    public bool abierto;
    public float tiempo;
    public Contador contador;
    public bool tienebotiquin;

    void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            contador = jugador.GetComponent<Contador>();
        }
        else
        {
            Debug.LogError("No se encontr� el objeto del jugador.");
        }
    }
    void Update()
    {
        if (dentro)
        {
            if(!abierto)
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

        if (!tienebotiquin)
        {
            if (tiempo >= 1)
            {
                

                if (dentro)
                {
                    letra.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (contador.puedeRecoger)
                        {
                            contador.contador++;
                            anim.SetBool("Lotiene", true);
                            contador.UpdateBotiquinText();
                            tienebotiquin = true;
                            tiempo = 1;
                            letra.SetActive(false);
                        }


                    }
                }


            }
            
        }
        else
        {
            tiempo = 0;
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
            dentro=false;
            letra.SetActive(false);
        }
    }
}