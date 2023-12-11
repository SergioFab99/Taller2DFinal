using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjetoEscena : MonoBehaviour
{

    public Animator animllaves;
    public GameObject anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetActive(true);
            Debug.Log("El jugador ha entrado en el trigger.");

            if (GameManager.instance.numLlaves == 3)
            {
                Debug.Log("El jugador tiene 3 llaves. Cargando la escena NivelBoss.");
                animllaves.SetBool("tres llaves", true);
                SceneManager.LoadScene("Bunker");
            }
            else if (GameManager.instance.numLlaves == 2)
            {
                Debug.Log("El jugador tiene 2 llaves");
                animllaves.SetBool("dos llaves", true);
            }
            else if (GameManager.instance.numLlaves == 1)
            {
                Debug.Log("El jugador tiene 1 llave");
                animllaves.SetBool("una llave", true);
            }
            else if (GameManager.instance.numLlaves == 0)
            {
                Debug.Log("El jugador tiene 0 llaveS");
                animllaves.SetBool("sin llaves", true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetActive(false);
    }
}
   