using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class collisiona : MonoBehaviour
{
    public TextMeshProUGUI textrecordatorio;
    public Collider2D esteCollider; // Asigna el Collider2D deseado desde el Inspector

    void Start()
    {
        // Puedes asignar esteCollider en el Inspector o descomentar la línea siguiente
        // esteCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ActivarDesactivarRecordatorio("Recuerda que el revólver solo tiene 5 balas."));

            // Desactiva el collider
            if (esteCollider != null)
            {
                esteCollider.enabled = false;
            }
        }
    }

    void Update()
    {
        // Tu lógica de Update, si es necesario
    }

    IEnumerator ActivarDesactivarRecordatorio(string mensaje)
    {
        textrecordatorio.text = mensaje;
        yield return new WaitForSeconds(5f);
        textrecordatorio.text = "";
    }
}