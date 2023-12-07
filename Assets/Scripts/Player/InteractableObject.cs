using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
    public GameObject Canvas;
    public SpriteRenderer object1;
    public bool objectInRange = false;
    void Start()
    {
        Canvas.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectInteraction"))
        {
            objectInRange = true;
            object1.color = new Color(object1.color.r, object1.color.g, object1.color.b, 1f);

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjectInteraction"))
        {
            objectInRange = false;
            object1.color = new Color(object1.color.r, object1.color.g, object1.color.b, 0f);
           

        }
    }
    void Update()
    {
        if (objectInRange && Input.GetKeyDown(KeyCode.E))
        {
            Canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}