using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensajedellaves : MonoBehaviour
{
    public float distanciaParaMensaje = 2.0f; // Distancia para mostrar el mensaje
    public GameObject jugador; // Referencia al jugador

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(jugador.transform.position, transform.position) <= distanciaParaMensaje)
        {
            Debug.Log("Necesitas 3 llaves para poder pasar");
        }
    }
}
