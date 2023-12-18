using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarvictoria : MonoBehaviour
{
    public GameObject gameobject;

    misionescumplidas misiones;
    void Start()
    {
      
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            misiones = jugador.GetComponent<misionescumplidas>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador.");
        }
    }
    void Update()
    {
        // Verificar si el GameObject ha sido destruido (referencia nula)
        if (gameobject == null)
        {
            // Cargar la escena de victoria
            SceneManager.LoadScene("NombreDeLaEscenaDeVictoria");
        }
    }


}