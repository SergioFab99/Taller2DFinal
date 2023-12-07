using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private EventManager Manager;
    private void Start() {
        Manager = GetComponent<EventManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EventTrigger"))
        {
            collision.gameObject.GetComponent<EventManager>().ActivateEvent(Manager);
        }
    }
}
