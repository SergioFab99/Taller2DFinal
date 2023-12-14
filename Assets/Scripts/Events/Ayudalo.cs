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
    public bool curada;
    public bool dentro;
    public bool misionaceptada;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            dentro = true;
            letra.SetActive(true);
            
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
        if (dentro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                textMesh.text = "Encuentra un botiquin y ayudala";
                afirma.SetActive(false);
                letra.SetActive(false);
                misionaceptada = true;
            }
        }
    }

    void usarbotiquin()
    {
        if (dentro)

            if(misionaceptada)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    textMesh.text = "Encuentra un botiquin y ayudala";
                    afirma.SetActive(false);
                    letra.SetActive(false);
                }
            }
        
    }
}
