using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.UI;

public class SceneChangerTransition : MonoBehaviour
{
    public Image imagen;
    public bool NoBoton;
    public bool Entrada;
    float Tiempo;
    bool Click;

    public string Escena;


    // Update is called once per frame
    public void OnClick()
    {
        Click = true;
    }
    void Update()
    {
        if (Click || NoBoton)
        {
            if (Entrada)
            {
                StartCoroutine(TransicionEntrada());

            }
            else
            {
                StartCoroutine(TransicionSalida());

            }
        }
    }

    IEnumerator TransicionEntrada()
    {
        imagen.enabled = true;
        Tiempo += Time.deltaTime * 0.2f;

        if (Tiempo <= 1)
        {
            imagen.fillAmount += Tiempo;
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(Escena);
    }

    IEnumerator TransicionSalida()
    {
        imagen.enabled = true;
        Tiempo += Time.deltaTime * 0.2f;

        if (Tiempo <= 1)
        {
            imagen.fillAmount -= Tiempo;
        }

        yield return null;
    }
}