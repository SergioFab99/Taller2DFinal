using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misionescumplidas : MonoBehaviour
{
    public Ayudalo ayuda1;
    public Ayudalo2 ayuda2;
    public bool mision1completadaconexito;
    public bool mision2completadaconexito;
    void Start()
    {
        
            // ayuda1 = GetComponent<Ayudalo>();
           //  ayuda2 = GetComponent<Ayudalo2>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ayuda1.misionterminada)
        {
            if(!ayuda1.muerta)

            {
                mision1completadaconexito = true;  
            }
            else
            {
                mision2completadaconexito = false;
            }

        }

        if(ayuda2.misionterminada)
        {
            if(!ayuda2.muerta)
            {
                mision2completadaconexito = true;
            }
            else
            {
                mision2completadaconexito = false;
            }
        }
    }
}
