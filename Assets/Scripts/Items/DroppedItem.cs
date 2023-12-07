using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    public bool ispickable;
    SpriteRenderer spriteRenderer;
    Inventario inventario;
    Item ItemDropped;
    [SerializeField] private bool SetDrop;

    void Start()
    {
        inventario = GameObject.Find("Player").GetComponent<Inventario>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ispickable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(!inventario.IsInventoryFull())
                {
                    inventario.PickupItem(ItemDropped);
                    Destroy(gameObject);
                }
            }
        }
    }
    public void SetPickAble()
    {
        ispickable = true;
        spriteRenderer.color = ItemDropped.GetColor();
    }
    public void SetUnpickAble()
    {
        ispickable = false;
        spriteRenderer.color = Color.white;
    }
    
    private void Randomize()
    {
        if(!SetDrop)
        {
            int num = Random.Range(1, 11);
            switch (num)
            {
                case int i when i > 5:
                    ItemDropped = new Jernga();
                    break;
                case int i when i <= 5:
                    ItemDropped = new MunicionExtra();
                    break;
            }
        }
    }
}
