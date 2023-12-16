using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.EventSystems.EventTrigger;

public class Sobre2 : MonoBehaviour
{
    public Ayudalo2 Ayudalo;
    public MovimientoAutomatico mov;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            if (collision.CompareTag("Bala"))
            {
                Ayudalo.muerta = true;
                mov.muerta = true;
                Destroy(collision.gameObject);

            }
        
    }
    void Start()
    {
        GameObject ayuda = GameObject.FindGameObjectWithTag("Survivor");
        if (ayuda != null)
        {
            Ayudalo = gameObject.GetComponent<Ayudalo2>();

        }
        GameObject Survivor = GameObject.FindGameObjectWithTag("Survivor");
        if (Survivor != null)
        {
            mov = Survivor.GetComponent<MovimientoAutomatico>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
