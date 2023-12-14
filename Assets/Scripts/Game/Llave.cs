using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public GameManager gameManager;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.RecolectarLlave();
            Destroy(gameObject);
        }
    }
}