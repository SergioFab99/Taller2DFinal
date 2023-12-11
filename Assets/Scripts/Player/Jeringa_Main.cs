using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Jeringa_Main : MonoBehaviour
{
    private Jeringa_Use jeringaUseScript; // Referencia al script Jeringa_Use

    private void Start()
    {
        // Obtener el componente Jeringa_Use del GameObject actual
         jeringaUseScript = GetComponent<Jeringa_Use>();

        if (jeringaUseScript != null)
        {
            ProbarJeringa();
        }
        else
        {
            UnityEngine.Debug.LogError("No se encontró el componente Jeringa_Use en el GameObject actual.");
        }
    }

    private void ProbarJeringa()
    {
        
        jeringaUseScript.UsarJeringa();

        bool invulnerableAhora = jeringaUseScript.EstaInvulnerable();
        UnityEngine.Debug.Log("¿Está Invulnerable? " + invulnerableAhora);
    }
}
