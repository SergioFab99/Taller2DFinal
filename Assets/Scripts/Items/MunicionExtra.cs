using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionExtra : Item
{
    Sprite sprite = Resources.Load<Sprite>("Municion");
    public override void Use()
    {
        Debug.Log("Usaste municion");
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
        return Color.gray;
    }
}
