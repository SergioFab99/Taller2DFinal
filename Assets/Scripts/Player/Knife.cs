using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Knife : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject Player;
    public GameObject knifePrefab;
    

    public float meleeCooldown = 0.9f;
    private float currentCooldown = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
    }




    private void Checkmelee()
    {
        currentCooldown -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Escape) && currentCooldown <= 0)
        {
            GameObject Knife = Instantiate(knifePrefab);
            Knife.transform.rotation = transform.rotation;

            currentCooldown = meleeCooldown;
        }
                

        
    }
}
