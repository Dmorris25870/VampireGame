using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartaAbyss.Items
{
	[CreateAssetMenu(fileName = "NewArmour", menuName = "ScriptableObjects/Item/Armour")]
	public class Armour : ItemBase
	{
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
}