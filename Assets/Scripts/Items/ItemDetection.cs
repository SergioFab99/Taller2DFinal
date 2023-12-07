using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
    Inventario Inventario;
    private void Awake()
    {
        Inventario = GetComponent<Inventario>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            DroppedItem droppedItem = collision.GetComponent<DroppedItem>();
            droppedItem.SetPickAble();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Item"))
        {
            DroppedItem droppedItem = collision.GetComponent<DroppedItem>();
            droppedItem.SetUnpickAble();
        }
    }
}
