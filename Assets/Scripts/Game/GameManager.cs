using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Referencia estática para un fácil acceso desde otros scripts

    public int numLlaves = 0;
    public GameObject ObjetoEscena;
    public TextMeshProUGUI contadorllaves;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Opcional, mantiene este objeto entre escenas
    }

    public void RecolectarLlave()
    {
        numLlaves++;
        Debug.Log("Encuentra las llaves ( " + numLlaves + "/3)");
        contadorllaves.text = "Encuentra las llaves ( " + numLlaves + "/3)";

        if (numLlaves == 3)
        {
            ObjetoEscena.SetActive(true); // Habilita el GameObject
        }
    }
}
