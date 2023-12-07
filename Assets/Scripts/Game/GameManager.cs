using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir este namespace para manejar las escenas

public class GameManager : MonoBehaviour
{
    public int numLlaves = 0;

    public GameObject objetoParaHabilitar; // Referencia al GameObject que se habilitará

    public void RecolectarLlave()
    {
        numLlaves++;
        Debug.Log("Has recolectado una llave! Ahora tienes " + numLlaves + " llaves.");

        if (numLlaves == 3)
        {
            objetoParaHabilitar.SetActive(true); // Habilita el GameObject
        }
    }

    // Llamado cuando el GameObject habilitado colisiona con el jugador
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el GameObject del jugador tenga el tag "Player"
        {
            SceneManager.LoadScene("NivelBoss"); // Carga la escena "NivelBoss"
        }
    }
}
