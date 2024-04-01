using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartaAbyss.Inventory
{
	public class DropItemScriptLITE : MonoBehaviour
	{
		public InventoryGridScriptLITE grid;
		public ItemDragLITE item;

		public void ItemToDrop(ItemDragLITE item2)
		{
			item = item2;
			grid = item.transform.parent.GetComponent<InventoryGridScriptLITE>();
		}

		public void Drop()
		{
			item.originalPos = item.rect.anchoredPosition;
			GameObject.FindGameObjectWithTag("MainCamera").SendMessage("RemoveItem", item.GetComponent<ItemDragLITE>()); //in case you're making equipable items
			grid.SendMessage("RemoveItem", item);
			transform.parent.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
		}
	}
}