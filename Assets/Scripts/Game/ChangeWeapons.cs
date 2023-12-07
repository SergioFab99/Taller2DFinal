using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeWeapons : MonoBehaviour
{
    //public GameObject object1;
    //public GameObject object2;
    public Image spriteBig;

    public Sprite imageState1;
    public Sprite imageState2;

    private int state = 0;
    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            state = 1;
        }
        else if (scroll < 0f)
        {
            state = 2;
        }

        ActualizarEstado();
    }

    private void Start()
    {
        state = 1; // Establecer el estado inicial en 1
        ActualizarEstado();
    }

    private void ActualizarEstado()
    {
        if (state == 1)
        {
            //object1.SetActive(true);
            //object2.SetActive(false);
            spriteBig.sprite = imageState1;
           
        }
        else if (state == 2)
        {
            //object1.SetActive(false);
            //object2.SetActive(true);
            spriteBig.sprite = imageState2;
            
        }
    }


}

