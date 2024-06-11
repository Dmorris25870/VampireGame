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
    [SerializeField] private string m_itemName;
    [SerializeField] private Sprite m_itemImage;
    [SerializeField] private string m_itemText;
    [SerializeField] private int m_itemValue;
    [SerializeField] private Rarity m_itemRarity;
    [SerializeField] private int m_itemHeight;
    [SerializeField] private int m_itemWidth;
    [SerializeField] private int m_itemLevel;
    [SerializeField] public float itemWeight;
    [SerializeField] private ItemType m_itemType;

    [Header("Consumable Info")]
    [SerializeField] private int m_healthRestore;
    [SerializeField] private int m_bloodRestore;
}