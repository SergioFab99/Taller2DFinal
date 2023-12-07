using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float velocidadMov;
    [SerializeField] public Transform[] puntosMov;
    [SerializeField] private float distanciaMinima;

    [SerializeField] private int numeroAleatorio;

    

    void Start()
    {
        numeroAleatorio = Random.Range(0, puntosMov.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[numeroAleatorio].position, velocidadMov * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMov[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntosMov.Length);
        }
        
    }

   
}
