using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSpawner : MonoBehaviour
{
    public GameObject enemigoPrefab; // Arrastra aquí el prefab del enemigo
    public int cantidadMaximaEnemigos = 10;
    public float tiempoEntreGeneraciones = 5.0f; // Tiempo entre generación de enemigos
    public float radioSpawn = 10.0f; // Radio de spawn alrededor del spawner
    public float distanciaMinimaSpawn = 5.0f; // Distancia mínima desde el spawner al jugador

    private int enemigosGenerados = 0;
    private bool generando = false;
    private GameObject jugador; // Referencia al jugador

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player"); // Busca el jugador por su etiqueta
        StartCoroutine(GenerarEnemigosConIntervalo());
    }

    IEnumerator GenerarEnemigosConIntervalo()
    {
        while (enemigosGenerados < cantidadMaximaEnemigos && jugador != null)
        {
            if (!generando)
            {
                generando = true;
                Vector3 spawnPosition;
                
                // Genera una posición aleatoria dentro del radioSpawn
                do
                {
                    spawnPosition = transform.position + Random.insideUnitSphere * radioSpawn;
                    spawnPosition.z = 0f;
                } while (Vector3.Distance(spawnPosition, jugador.transform.position) < distanciaMinimaSpawn);
                
                Instantiate(enemigoPrefab, spawnPosition, Quaternion.identity);
                enemigosGenerados++;

                yield return new WaitForSeconds(tiempoEntreGeneraciones);
                generando = false;
            }
            else
            {
                yield return null;
            }
        }
    }
}