using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Comsumable,
    Throwable
}

[CreateAssetMenu(fileName = "Item", menuName = "Unknown/Create new item")]
public class Items : ScriptableObject
{
    public string itemName;

    [TextArea]
    public string description;

    public Sprite sprite;
    public ItemType itemType;
}
