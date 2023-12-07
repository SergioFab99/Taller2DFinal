using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public abstract void Use();
    public abstract void Pickup();
    public abstract Sprite GetSprite();
    public abstract Color GetColor();
}
