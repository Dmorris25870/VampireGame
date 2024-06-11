using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Items
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
		[SerializeField] private EquipmentType m_slot;
		[SerializeField] private int m_armour;
	}
}