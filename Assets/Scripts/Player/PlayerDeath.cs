using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ContadorJeringa contador;
    public GameObject imagenPistola;
    public GameObject textpistola;
    public bool tienepistola;
    public GameObject pistolaFire;
    public Animator animator;

    public bool tieneMetralleta;
    public GameObject textmetralleta;

    tp tp;
    public void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            contador = jugador.GetComponent<ContadorJeringa>();
        }
        else
        {
            Debug.LogError("No se encontr� el objeto del jugador.");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pistola"))
        {
            imagenPistola.SetActive(true);
            animator.SetBool("tienepistola", true);
            textpistola.SetActive(true);
            tienepistola = true;
            pistolaFire.SetActive(true);

        }

        if (other.gameObject.CompareTag("akm"))
        {
            animator.SetBool("tieneotrarma", true);
            animator.SetBool("tienepistola", false);
            tieneMetralleta = true;
            textmetralleta.SetActive(true);
            //textpistola.SetActive(true);
            //tienepistola = true;
            //pistolaFire.SetActive(true);

        }
        if (!contador.usando)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                    SceneManager.LoadScene("Derrota");
               
            }
           
        }
        else
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                contador.corazon.SetBool("Usado", true);
                contador.corazon.SetBool("Proceso", false);
                contador.usando = false;
            }
        }
        
       
    }
}
