using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerAK47 : MonoBehaviour
{
    private ControlArmas controlArmas; // Agrega esta línea

    void Start()
    {
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<ControlArmas>(); // Ajusta la etiqueta según tu configuración
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ajusta la etiqueta según tu configuración
        {
            controlArmas.UpNivelDeArma();
            Destroy(gameObject);
        }
    }
}
