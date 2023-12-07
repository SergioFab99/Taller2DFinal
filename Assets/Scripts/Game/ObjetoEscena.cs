using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjetoEscena : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter2D called with: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador ha entrado en el trigger.");

            if (GameManager.instance.numLlaves == 3)
            {
                Debug.Log("El jugador tiene 3 llaves. Cargando la escena NivelBoss.");
                SceneManager.LoadScene("NivelBoss");
            }
            else
            {
                Debug.Log("El jugador no tiene suficientes llaves.");
            }
        }
    }

}
