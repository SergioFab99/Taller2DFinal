using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI txtbotiquin;
    public int contador = 0;
    public bool puedeRecoger = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Botiquin"))
        {
            if (puedeRecoger)
            {
                contador++;
                UpdateBotiquinText();
                Destroy(collision.gameObject);
            }
        }
    }

    public void UpdateBotiquinText()
    {
        if (txtbotiquin != null)
        {
            txtbotiquin.text = contador.ToString();
        }
    }

    private void Update()
    {
        if (contador >= 1)
        {
            puedeRecoger = false;
        }
        else
        {
            puedeRecoger= true;
        }
        
    }
}