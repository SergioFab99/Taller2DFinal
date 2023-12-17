using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public GameObject pistola, metralleta;
    private int armaSeleccionada = 0;
    [SerializeField] private int NivelDeArma = 1;

    public Animator anim;
    void Start()
    {
        // Al inicio, activa solo la pistola
        CambiarArma(0);

    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f && NivelDeArma != 1)
        {
            if (scroll > 0f)
            {
                armaSeleccionada++;
                if (armaSeleccionada > 1) armaSeleccionada = 0;
                
            }
            else
            {
                armaSeleccionada--;
                if (armaSeleccionada < 0) armaSeleccionada = 1;
                

            }
            CambiarArma(armaSeleccionada);
        }


        if(armaSeleccionada == 0)
        {
            anim.SetBool("sheriff", true);
            anim.SetBool("pistola", false);
        }
        else
        {
            anim.SetBool("pistola", true);
            anim.SetBool("sheriff", false);
        
        }
    }
    public void UpNivelDeArma()
    {
        NivelDeArma++;
    }

    void CambiarArma(int arma)
    {
        pistola.SetActive(arma == 0);
        metralleta.SetActive(arma == 1);
    }
}