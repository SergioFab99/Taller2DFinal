using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public int numLlaves = 0;

    public GameObject objetoAMover;
    public float velocidadMovimiento = 1f;

    public void RecolectarLlave()
    {

        numLlaves++;

        if (numLlaves == 3)
        {
            StartCoroutine(MoverObjeto());
        }

        Debug.Log("Has recolectado una llave! Ahora tienes " + numLlaves + " llaves.");

    }

    IEnumerator MoverObjeto()
    {

        float objetivoY = objetoAMover.transform.position.y + 5f;

        while (objetoAMover.transform.position.y < objetivoY)
        {
            objetoAMover.transform.Translate(0, velocidadMovimiento * Time.deltaTime, 0);
            yield return null;
        }

    }

}
