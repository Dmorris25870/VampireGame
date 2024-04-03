using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Items;

namespace VartraAbyss.Abilities
{
	public abstract class Ability : MonoBehaviour
	{
		[SerializeField] protected DamageType m_damageType;
		[SerializeField] protected int m_damageAmount;
		[SerializeField] protected float m_coolDownTimeInSeconds;
		[SerializeField] protected float m_abilityDistance;

		public DamageType DamageType { get { return m_damageType; } }
		public int DamageAmount { get { return m_damageAmount; } }
		public float CoolDownTimeInSeconds { get { return m_coolDownTimeInSeconds; } }
		public float AbilityDistance { get { return m_abilityDistance; } }
	}
}