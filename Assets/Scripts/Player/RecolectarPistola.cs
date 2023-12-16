using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RecolectaPistola : MonoBehaviour
{
    public GameObject pistola;
    
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
            // Activar la pistola al entrar en el trigger
            
        pistola.SetActive(true);
        
        // Destruir el trigger después de activar la pistola
        Destroy(gameObject);
    }
}
}
