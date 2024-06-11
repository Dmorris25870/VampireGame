using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Inventory
{
	public class DropItemScriptLITE : MonoBehaviour
	{
		public InventoryGridScriptLITE grid;
		public ItemDragLITE item;

		private void OnEnable()
		{

			EventManager.OnItemDropping += ItemToDrop;
		}

		private void OnDisable()
		{
			EventManager.OnItemDropping -= ItemToDrop;
		}

		public void ItemToDrop(ItemDragLITE item2)
		{
			item = item2;
			grid = item.transform.parent.GetComponent<InventoryGridScriptLITE>();
		}

		public void Drop()
		{
			item.originalPos = item.rect.anchoredPosition;
			EventManager.OnItemDrag?.Invoke(item);
			transform.parent.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
		}
	}
}