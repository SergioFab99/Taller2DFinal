using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjetoEscena : MonoBehaviour
{

    public Animator animllaves;
    public GameObject anim;
    public GameObject letraE;
    public Animator bunker;
    public float time;
    public bool abierto;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetActive(true);

            if (GameManager.instance.numLlaves == 3)
            {
                Debug.Log("El jugador tiene 3 llaves. Cargando la escena NivelBoss.");
                animllaves.SetBool("tres llaves", true);
                abierto = true;
                bunker.SetBool("Abrir", true);
                animllaves.SetBool("tresllavesyabrir", true);
                anim.SetActive(false);
                letraE.SetActive(true);
                if (time > 1)
                {
                   if(Input.GetKeyDown(KeyCode.E))
                    {
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        SceneManager.LoadScene("Bunker");
                        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
                        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("HUD"));
                        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("CanvasEventos"));
                        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Pausa"));
                       
                        player.transform.position = new Vector3(-22, 14, 0); // ajusta x, y, z según sea necesario
                    }

                }
                }
                
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
    

    
    private void Update()
    {
        if(abierto)
        {
            time += 1 * Time.deltaTime;
        }
        if (abierto && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Bunker");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetActive(false);
    }
}
   