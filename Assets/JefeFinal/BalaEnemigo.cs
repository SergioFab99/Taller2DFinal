using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public bool mover;
    public GameObject PosicionInicial;
    public GameObject Jefe;
    bool primeraVezActivada = true;
    public bool aparecer;
    bool AnimacionInvocacion;
    void Awake()
    {
        aparecer = true;
        Jefe.GetComponent<JefeFinal>().Invocado = true;
    }

    void OnEnable()
    {
        if (primeraVezActivada)
        {

            transform.position = PosicionInicial.transform.position;
            primeraVezActivada = false;
            Jefe.GetComponent<JefeFinal>().Invocado = false;


        }
        if (aparecer)
        {
            transform.position = PosicionInicial.transform.position;
            aparecer = false;
            Jefe.GetComponent<JefeFinal>().Invocado = false;

        }
    }

    void Update()
    {
       
        if (mover)
        {
            Vector2 direccion = (Player.transform.position - transform.position).normalized;
            transform.Translate(direccion* speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bala") || collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameObject.transform.position = PosicionInicial.transform.position;
            aparecer = true;
            Jefe.GetComponent<JefeFinal>().Invocado = true;


        }

    }
}
