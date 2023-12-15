using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContadorJeringa : MonoBehaviour
{
    public TextMeshProUGUI txtjeringa;
    public int contador = 0;
    public bool usando = false;
    public bool puedeRecoger = true;
    public Animator corazon;

    public void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jeringa"))
        {
            if (puedeRecoger)
            {
                contador++;
                UpdateJeringaTxt();
                Destroy(collision.gameObject);
            }

        }
    }

    public void UpdateJeringaTxt()
    {
        txtjeringa.text = contador.ToString();
    }

    private void Update()
    {
        if (contador >= 3)
        {
            puedeRecoger = false;

        }

        if (contador == 2)
        {
            UseJeringa();
            puedeRecoger = true;
        }
        if (contador == 1)
        {
            UseJeringa();
            puedeRecoger = true;
        }
        if (contador < 1)
        {
            puedeRecoger = true;
        }
    }

    public void UseJeringa()
    {
        if(!usando)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //textMesh.text = " .";
                contador--;
                UpdateJeringaTxt();
                corazon.SetBool("Proceso",true);
                usando = true;

            }
        }
            
        
    }
}