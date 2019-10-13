using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make the object visible in Unity
[System.Serializable]
public class Item
{
    public Sprite itemSprite;
    [TextArea(3,10)]
    public string name;
    [TextArea(3,10)]
    public string itemDescription;

}
