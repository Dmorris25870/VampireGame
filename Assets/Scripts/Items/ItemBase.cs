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
    [SerializeField] int itemSize;
    [SerializeField] int itemLevel;
    [SerializeField] public float itemWeight;
    [SerializeField] ItemType itemType;

    private enum EquipmentType
    {
        Head,
        Shoulders,
        Arms,
        Chest,
        Hands,
        Legs,
        Feet,
        Finger,
        Neck
    }

    [Header("Equipment Info")]
    [SerializeField] EquipmentType slot;
    [SerializeField] int armour;
}
