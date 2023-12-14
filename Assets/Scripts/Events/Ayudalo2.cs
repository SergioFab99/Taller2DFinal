using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ayudalo2 : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject letra;
    public GameObject afirma;
    public bool muerta;
    public bool dentro;
    public bool misionaceptada;
    public Contador contador;
    public bool misionterminada;
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
            if (!muerta)
            {
                dentro = true;
                letra.SetActive(true);
            }

        }
        if (collision.CompareTag("Bala"))
        {
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
    // Update is called once per frame
    void Update()
    {

        if (!muerta)
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
            misionterminada = true;
            textMesh.text = "Completo.";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("notienes");
                //letra.SetActive(false);
            }

        }

    }
}




