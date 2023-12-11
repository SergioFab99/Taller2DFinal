//using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Inventario : MonoBehaviour
{
    /*
    //Logic
    //Item[] Slots;
    int SelectedSlot = 0;
    //UI
    [SerializeField] GameObject UISlot1;
    [SerializeField] GameObject UIHighlight1;
    [SerializeField] GameObject UISlot2;
    [SerializeField] GameObject UIHighlight2;
    [SerializeField] GameObject UISlot3;
    [SerializeField] GameObject UIHighlight3;

    private void Awake()
    {

        //Slots = new Item[3];
        Slots[0] = null;
        Slots[1] = null;
        Slots[2] = null;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateUI();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedSlot = 1;
            UpdateSelected();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedSlot = 2;
            UpdateSelected();

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedSlot = 3;
            UpdateSelected();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UseItem(SelectedSlot - 1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    void Drop()
    {
        UpdateUI();
    }

    void UseItem(int n)
    {
        if (Slots[n] != null)
        {
        Slots[n].Use();
        Slots[n] = null;
        ClearSpace();
        }    
    }
    void UpdateUI()
    {
        if (Slots[0] != null) { UISlot1.GetComponent<UnityEngine.UI.Image>().sprite = Slots[0].GetSprite(); }
        if (Slots[1] != null) { UISlot2.GetComponent<UnityEngine.UI.Image>().sprite = Slots[1].GetSprite(); }
        if (Slots[2] != null) { UISlot3.GetComponent<UnityEngine.UI.Image>().sprite = Slots[2].GetSprite(); }
    }
    void UpdateSelected()
    {
        switch (SelectedSlot) {
            case 1:
                UIHighlight1.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
                UIHighlight2.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                UIHighlight3.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                break;
            case 2:
                UIHighlight1.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                UIHighlight2.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
                UIHighlight3.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                break;
            case 3:
                UIHighlight1.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                UIHighlight2.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                UIHighlight3.GetComponent<UnityEngine.UI.Image>().color = Color.yellow;
                break;
        }
    }

    private void ClearSpace()
    {
        UISlot1.GetComponent<UnityEngine.UI.Image>().sprite = null;
        UISlot2.GetComponent<UnityEngine.UI.Image>().sprite = null;
        UISlot3.GetComponent<UnityEngine.UI.Image>().sprite = null;
        UpdateUI();
        UpdateSelected();
    }

    /*public void PickupItem(Item PickedItem)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i] == null)
            {
                Slots[i] = PickedItem;
                UpdateUI();
                return;
            }
        }
    }
    public bool IsInventoryFull()
    {
        if (Slots[0] == null || Slots[1] == null || Slots[2] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }*/
}
