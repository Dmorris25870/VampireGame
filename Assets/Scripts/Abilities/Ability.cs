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

		[SerializeField] protected DamageType damageType;
		[SerializeField] protected int damageAmount;
		[SerializeField] protected int bloodCostAmount;
		[SerializeField] protected float coolDownTimeInSeconds;
		[SerializeField] protected float abilityDistance;

		public DamageType DamageType => damageType;
		public int DamageAmount => damageAmount;
		public int BloodCostAmount => bloodCostAmount;
		public float CoolDownTimeInSeconds => coolDownTimeInSeconds;
		public float AbilityDistance => abilityDistance;
	}
}