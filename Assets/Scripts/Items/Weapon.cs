using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartaAbyss.Items
{
	[CreateAssetMenu(fileName = "NewWeapon", menuName = "ScriptableObjects/Item/Weapon")]
	public class Weapon : ItemBase
	{
		private DamageType m_damageType;
		[SerializeField] private int m_damageAmount;

		public DamageType DamageType { get { return m_damageType; } }
		public int DamageAmount { get { return m_damageAmount; } }
	}
}