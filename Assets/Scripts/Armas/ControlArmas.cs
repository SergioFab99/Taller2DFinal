using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArmas : MonoBehaviour
{
    public GameObject pistola, metralleta;
    private int armaSeleccionada = 0;
    [SerializeField] private int NivelDeArma = 1;

    public GameObject textpistola;
    public GameObject textmetralleta;

    public PlayerDeath PlayerDeath;
    public Animator anim;
    public Animator animPlayer;
    public bool activarevolver;
    public bool activarpistola;
    void Start()
    {
        // Al inicio, activa solo la pistola
        PlayerDeath playerDeath = gameObject.GetComponentInChildren<PlayerDeath>();
       
        
            CambiarArma(0);
            activarevolver = true;
        
      

        
    }

    void Update()
    {
        if(PlayerDeath.tienepistola)
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


            if (armaSeleccionada == 0)
            {
                anim.SetBool("sheriff", true);
                anim.SetBool("pistola", false);
                textpistola.SetActive(true);
                textmetralleta.SetActive(false);
                activarevolver = true;
                activarpistola = false;
                animPlayer.SetBool("TienePistola",true);
                animPlayer.SetBool("TieneMetralleta", false);
            }
            else
            {
                anim.SetBool("pistola", true);
                anim.SetBool("sheriff", false);
                textpistola.SetActive(false);
                textmetralleta.SetActive(true);
                activarevolver = false;
                activarpistola = true;
                animPlayer.SetBool("TieneMetralleta", true);
                animPlayer.SetBool("TienePistola", false);
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
    }
}