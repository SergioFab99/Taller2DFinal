using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpArma : MonoBehaviour
{
    GameObject Player;
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Player.transform.position) <= 5)
        {
            Player.GetComponent<ControlArmas>().UpNivelDeArma();
            Destroy(gameObject);
        }
    }
}
