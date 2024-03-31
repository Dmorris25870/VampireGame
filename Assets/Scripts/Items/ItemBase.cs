using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Item/Item")]
public class ItemBase : ScriptableObject
{
    private enum Rarity
    {
        Normal,
        Magic,
        Rare,
        Legendary
    }
    private enum ItemType
    {
        Generic,
        Consumable,
        Equipment
    }

    [Header("Item Info")]
    [SerializeField] string itemName;
    [SerializeField] Sprite itemImage;
    [SerializeField] string itemText;
    [SerializeField] int itemValue;
    [SerializeField] Rarity itemRarity;
    [SerializeField] int itemHeight;
    [SerializeField] int itemWidth;
    [SerializeField] int itemLevel;
    [SerializeField] public float itemWeight;
    [SerializeField] ItemType itemType;

    [Header("Consumable Info")]
    [SerializeField] int healthRestore;
    [SerializeField] int bloodRestore;
}
