using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.UI;

public class FindeAnimacion : MonoBehaviour
{
    public Animator anim;
    public string nombreDeEscena;
    public Image imagen;

    void Start()
    {
        StartCoroutine(EsperarAnimacion());
    }

    IEnumerator EsperarAnimacion()
    {

        

        // Esperar hasta que la animación haya terminado
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        float tiempoPasado = 0f;
        float duracionAnimacion = 1.5f;  // Ajusta según sea necesario

        while (tiempoPasado < duracionAnimacion)
        {
            imagen.fillAmount = tiempoPasado / duracionAnimacion;
            tiempoPasado += Time.deltaTime;
            yield return null;
        }

        // Cambiar a la nueva escena
        SceneManager.LoadScene(nombreDeEscena);
    }
}