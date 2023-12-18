using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{
    public string tagDestino = "TPDestino";
    public Transform destino;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportarJugador(other.transform);
        }
    }

    private void TeleportarJugador(Transform jugadorTransform)
    {
        if (destino != null)
        {
            jugadorTransform.position = destino.position;
        }
        else
        {
            // Si no se ha establecido un destino, simplemente desactiva al jugador
            jugadorTransform.gameObject.SetActive(false);
        }
    }
}