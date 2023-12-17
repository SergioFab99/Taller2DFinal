using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion2 : MonoBehaviour
{
    public int municionAIncrementar = 30;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PlayerWeapon playerWeapon = other.gameObject.GetComponentInChildren<PlayerWeapon>();
            Metralleta metralleta = other.gameObject.GetComponentInChildren<Metralleta>();
            PlayerDeath playerDeath = other.gameObject.GetComponentInChildren<PlayerDeath>();
            if (metralleta.munici�n < 30)
            {
                if (playerDeath.tienepistola)
                {
                    if (metralleta != null)
                    {
                        metralleta.A�adirMunici�n(municionAIncrementar);
                    }

                    /*if (metralleta != null)
                    {
                        metralleta.A�adirMunici�n(municionAIncrementar);
                    }*/

                    Destroy(gameObject); // Destruye el objeto de munici�n despu�s de ser recolectado
                }

            }

        }
    }
}