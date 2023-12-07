using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    EventManager Manager;
    public bool Used; 
    [SerializeField] bool InRange = false;
    [SerializeField] GameObject UI;
    private void Start() {
        Manager = GetComponent<EventManager>();
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
    void Update()
    {
        if(!Used)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                int num = Random.Range(0,11);
                // Debug.Log(num);
                if(num > 5)
                {
                    Manager.ActivateEvent(Manager);
                    Used = true;
                }
                else 
                {
                    Used = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InRange = true;
            UI.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            InRange = false;
            UI.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
