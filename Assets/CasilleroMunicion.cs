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
    public PlayerWeapon contador;
    public bool tienemunicion;
    public bool encontrado;
    void Start()
    {
        
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
            
            tiempo = 1;
            if (dentro)
            {
                letra.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //buscar();
                    
                        if (!tienemunicion)
                        {
                            if (contador.munición < 10)
                            {
                                contador.munición = 10;
                                anim.SetBool("Lotiene", true);
                                contador.textmunicion.text = contador.munición.ToString();
                                tienemunicion = true;
                                letra.SetActive(false);
                            }

                        }
                    
                    

                }
            }


        }

    }

   /* void buscar()
    {

        contador = GameObject.Find("Player").GetComponent<PlayerWeapon>();
        if(contador = contador.GetComponent<PlayerWeapon>())
        {
            encontrado = true;
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador.");
            encontrado = false;
        }
    }*/
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