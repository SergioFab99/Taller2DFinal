using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Thoughts : MonoBehaviour
{
    public bool thouhtInRange = true;
    public GameObject canvas;
    void Start()
    {
        thouhtInRange = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ThoughtInteraction"))
        {
            thouhtInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ThoughtInteraction"))
        {
            thouhtInRange = false;
        }
    }
    void Update()
    {
        if(thouhtInRange)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
       
    }
}
