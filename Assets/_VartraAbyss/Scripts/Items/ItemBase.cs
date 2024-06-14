using UnityEngine;

[CreateAssetMenu(fileName = "NewItem" , menuName = "ScriptableObjects/Item/Item")]
public class ItemBase : ScriptableObject
{
	public enum Rarity
	{
		Normal,
		Magic,
		Rare,
		Legendary
	}
	public enum ItemType
	{
		Generic,
		Consumable,
		Equipment
	}

	[Header("Item Info")]
	public string itemName;
	public Sprite itemImage;
	public string itemText;
	public int itemValue;
	public Rarity itemRarity;
	public int itemHeight;
	public int itemWidth;
	public int itemLevel;
	public float itemWeight;
	public ItemType itemType;

	[Header("Consumable Info")]
	[SerializeField] private int m_healthRestore;
	[SerializeField] private int m_bloodRestore;
}