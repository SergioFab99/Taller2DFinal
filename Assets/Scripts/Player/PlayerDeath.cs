using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public ContadorJeringa contador;
    public void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            contador = jugador.GetComponent<ContadorJeringa>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador.");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
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
