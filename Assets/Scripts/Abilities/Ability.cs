using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Items;

namespace VartraAbyss.Abilities
{
	public abstract class Ability : MonoBehaviour
	{
		public enum AbilityNames
		{
			Unset,
			Claw,
			Bite,
			BloodProjectile
		}

		[SerializeField] protected DamageType m_damageType;
		[SerializeField] protected int m_damageAmount;
		[SerializeField] protected int m_bloodCostAmount;
		[SerializeField] protected float m_coolDownTimeInSeconds;
		[SerializeField] protected float m_abilityDistance;

		public DamageType DamageType { get { return m_damageType; } }
		public int DamageAmount { get { return m_damageAmount; } }
		public int BloodCostAmount { get { return m_bloodCostAmount; } }
		public float CoolDownTimeInSeconds { get { return m_coolDownTimeInSeconds; } }
		public float AbilityDistance { get { return m_abilityDistance; } }
	}
}