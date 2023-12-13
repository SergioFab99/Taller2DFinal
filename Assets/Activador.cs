using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    /*private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.CompareTag("Player"))
            {
                Boos2 profesoraScript = other.GetComponentInParent<Boos2>();
                if (profesoraScript != null)
                {
                    // Activar el disparo y almacenar la posición del jugador
                    profesoraScript.puedeDisparar = true;
                    profesoraScript.jugadorPosition = other.transform.position;
                }
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Boos2 profesoraScript = other.GetComponentInParent<Boos2>();
            if (profesoraScript != null)
            {
                // Continuar con el movimiento
                profesoraScript.puedeDisparar = false; // Aquí asegúrate de restablecer la capacidad de disparo
                profesoraScript.Mover(Vector2.zero); // Detener el movimiento (pasando Vector2.zero)
            }
        }
    }*/
}