using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ayudalo : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI textMesh;
    public GameObject letra;
    public GameObject afirma;
    public bool muerta;
    public bool dentro;
    public bool misionaceptada;
    public Contador contador;
    public bool misionterminada;

    public TextMeshProUGUI textrecordatorio;
    public bool yavisto = false;
    public bool yavista = false;
    

    void Start()
    {
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            contador = jugador.GetComponent<Contador>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto del jugador.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!muerta)
            {
                dentro = true;
                letra.SetActive(true);
            }

        }
        if (collision.CompareTag("Bala"))
        {
            animator.SetBool("Muerta", true);
            muerta = true;
            Destroy(collision.gameObject);
            letra.SetActive(false);
            afirma.SetActive(false);
            textMesh.text = "Fallaste.";

        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            dentro = false;
            letra.SetActive(false);
        }
    }
    void Update()
    {
        if(!muerta)
        {
            if (dentro)
            {
                if (!misionterminada)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        textMesh.text = "Encuentra un botiquin y ayudala.";
                        afirma.SetActive(false);
                        misionaceptada = true;
                        if(!yavisto)
                        {
                            StartCoroutine(ActivarDesactivarRecordatorio("Aprieta la letra C para ver tus nuevas misiones."));
                            yavisto = true;
                        }
                       
                    }

                }
            }
            if (dentro)
            {
                if (misionaceptada)
                {
                    if (!misionterminada)
                    {
                        if (contador.contador == 1)
                        {
                            usarbotiquin();
                           
                        }
                    }
                    else
                    {
                        letra.SetActive(false);
                    }

                }
            }
        }
    }


    void usarbotiquin()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            contador.contador = 0;
            contador.UpdateBotiquinText();
            animator.SetBool("Curada", true);
            misionterminada = true;
            textMesh.text = "Completo.";

            if (!yavista)
            {
                StartCoroutine(ActivarDesactivarRecordatorio("Completaste una misión."));
                yavista = true;
            }
        }
        else
        {
            // Solo mostrar el mensaje si no tienes botiquín
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("No tienes botiquín");
                //letra.SetActive(false);
            }
        }
    }
    IEnumerator ActivarDesactivarRecordatorio(string mensaje)
    {
        textrecordatorio.text = mensaje;
        yield return new WaitForSeconds(5f);
        textrecordatorio.text = "";
    }
}
