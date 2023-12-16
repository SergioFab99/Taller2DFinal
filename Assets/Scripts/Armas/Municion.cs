using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    public int municionAIncrementar = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerWeapon playerWeapon = other.gameObject.GetComponentInChildren<PlayerWeapon>();
            Metralleta metralleta = other.gameObject.GetComponentInChildren<Metralleta>();
            PlayerDeath playerDeath = other.gameObject.GetComponentInChildren<PlayerDeath>();
            if(playerWeapon.munición < 10)
            {
                if (playerDeath.tienepistola)
                {
                    if (playerWeapon != null)
                    {
                        playerWeapon.AñadirMunición(municionAIncrementar);
                    }

                    /*if (metralleta != null)
                    {
                        metralleta.AñadirMunición(municionAIncrementar);
                    }*/

                    Destroy(gameObject); // Destruye el objeto de munición después de ser recolectado
                }

            }

        }
    }
}