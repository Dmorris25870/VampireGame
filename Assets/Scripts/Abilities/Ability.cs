using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Items;

namespace VartraAbyss.Abilities
{
	public abstract class Ability : MonoBehaviour
	{
		private DamageType m_damageType;
		[SerializeField] private int m_damageAmount;
		[SerializeField] private float m_coolDownTimeInSeconds;

		public DamageType DamageType { get { return m_damageType; } }
		public int DamageAmount { get { return m_damageAmount; } }
		public float CoolDownTimeInSeconds { get { return m_coolDownTimeInSeconds; } }
	}
}