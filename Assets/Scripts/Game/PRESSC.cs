using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRESSC : MonoBehaviour
{
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Aseg�rate de que el Canvas est� desactivado al principio
        if (canvas != null)
        {
            canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica si la tecla 'C' est� siendo presionada
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Activa o desactiva el Canvas seg�n su estado actual
            if (canvas != null)
            {
                canvas.SetActive(!canvas.activeSelf);
            }
        }
    }
}