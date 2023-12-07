using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class ChangeSceneMenu : MonoBehaviour
{

    public string nombreDeLaEscena;
    public Animator botonAnimator;
    private bool clickeado = false;
    public List<Button> otrosBotones;
    public void OnClick()
    {
        if (!clickeado)
        {
            clickeado = true;
            botonAnimator.SetBool("Click", true);
            foreach (Button boton in otrosBotones)
            {
                boton.interactable = false;
            }

            StartCoroutine(CambiarEscenaDespuesDeRetraso(1.5f));
        }
    }

    private IEnumerator CambiarEscenaDespuesDeRetraso(float retraso)
    {
        yield return new WaitForSeconds(retraso);
        SceneManager.LoadScene(nombreDeLaEscena);
    }
}
