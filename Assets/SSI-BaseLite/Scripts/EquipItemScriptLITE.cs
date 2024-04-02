using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Inventory
{
	public class EquipItemScriptLITE : MonoBehaviour
	{
		public ItemDragLITE item;

		public void ItemToEquip(ItemDragLITE item2)
		{
			item = item2;
		}

		public void Equip()
		{
			GameObject.FindGameObjectWithTag("MainCamera").SendMessage("Equip", item.obj.GetComponent<ItemScriptLITE>());
			transform.parent.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
		}
	}
}