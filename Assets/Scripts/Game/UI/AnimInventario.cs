using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimInventario : MonoBehaviour
{
    public GameObject animacionBotiquin;
    public GameObject animacionJeringa;
    public GameObject animacionMunicion;
    public GameObject animacionCuchillo;

    private bool slot1Vacio = true;
    private bool slot2Vacio = true;
    private bool slot3Vacio = true;
    private bool slot4Vacio = true;

    private bool botiquinFIN = false;
    private bool jeringaFIN = false;
    private bool municionFIN = false;
    private bool cuchilloFIN = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ReproducirAnimacion(1, "Botiquin", animacionBotiquin, ref slot1Vacio);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReproducirAnimacion(2, "Jeringa", animacionJeringa, ref slot2Vacio);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ReproducirAnimacion(3, "Municion", animacionMunicion, ref slot3Vacio);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ReproducirAnimacion(4, "Cuchillo", animacionCuchillo, ref slot4Vacio);
        }
    }

    void ReproducirAnimacion(int slot, string tagObjeto, GameObject animacion, ref bool slotVacio)
    {
        if (TieneObjeto(tagObjeto) && slotVacio)
        {
            animacion.GetComponent<Animation>().Play();
            slotVacio = false;
        }
        else
        {
            ReproducirAnimacionVacio(slot, animacion);
        }
    }

    void ReproducirAnimacionVacio(int slot, GameObject animacion)
    {
        animacion.GetComponent<Animation>().Play("Vacio" + slot);
    }

    bool TieneObjeto(string tagObjeto)
    {
        return GameObject.FindGameObjectWithTag(tagObjeto) != null;
    }
    void UsarObjeto(string tagObjeto)
    {
        switch (tagObjeto)
        {
            case "Botiquin":
                botiquinFIN = true;
                break;
            case "Jeringa":
                jeringaFIN = true;
                break;
            case "Municion":
                municionFIN = true;
                break;
            case "Cuchillo":
                cuchilloFIN = true;
                break;
        }
        Destroy(GameObject.FindGameObjectWithTag(tagObjeto));
    }
}