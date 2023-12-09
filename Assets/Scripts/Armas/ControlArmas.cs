using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public GameObject pistola, metralleta, bazooka;
    private int armaSeleccionada = 0;
    [SerializeField] private int NivelDeArma = 1;
    void Start()
    {
        // Al inicio, activa solo la pistola
        CambiarArma(0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            armaSeleccionada++;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f && NivelDeArma != 1)
        {
            switch(NivelDeArma)
            {
                case 2:
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
                    break;
                case 3:
                    if (scroll > 0f)
                    {
                        armaSeleccionada++;
                        if (armaSeleccionada > 2) armaSeleccionada = 0;
                    }
                    else
                    {
                        armaSeleccionada--;
                        if (armaSeleccionada < 0) armaSeleccionada = 2;
                    }
                    CambiarArma(armaSeleccionada);
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
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
        bazooka.SetActive(arma == 2);
    }
}