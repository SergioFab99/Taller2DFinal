using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasilleroE : MonoBehaviour
{
    public GameObject letra;
    public Animator anim;
    public bool dentro;
    public bool abierto;


    void Update()
    {
       if(dentro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("Presionado", true);
                abierto = true;
            }
        }
        
       if(abierto)
        {
            letra.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            letra.SetActive(true);
            dentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Presionado", false);
            dentro=false;
            letra.SetActive(false);
        }
    }
}