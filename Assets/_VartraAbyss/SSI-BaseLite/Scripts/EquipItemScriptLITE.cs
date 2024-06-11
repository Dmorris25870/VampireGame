using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Inventory
{
	public class EquipItemScriptLITE : MonoBehaviour
	{
		public ItemDragLITE item;

		private void OnEnable()
		{

			EventManager.OnItemGiving += ItemToEquip;
		}

		private void OnDisable()
		{
			EventManager.OnItemGiving -= ItemToEquip;
		}

		public void ItemToEquip(ItemDragLITE item2)
		{
			item = item2;
		}

		public void Equip()
		{
			EventManager.OnItemEquip?.Invoke(item.obj.GetComponent<ItemScriptLITE>());
			transform.parent.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
		}
	}
}