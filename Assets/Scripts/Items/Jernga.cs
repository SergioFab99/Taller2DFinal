using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jernga : Item
{
    Sprite sprite = Resources.Load<Sprite>("Jeringa");
    public override void Use()
    {
        Debug.Log("Usaste Jeringa");
    }
    public override void Pickup()
    {

    }
    public override Sprite GetSprite()
    {
        return sprite;
    }
    public override Color GetColor()
    {
        return Color.green;
    }
}
