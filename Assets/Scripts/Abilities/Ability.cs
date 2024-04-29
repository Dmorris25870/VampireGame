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
			BloodProjectile,
			BloodShield,
			BloodWhip
		}

		[SerializeField] protected DamageType damageType;
		[SerializeField] protected int damageAmount;
		[SerializeField] protected int bloodCostAmount;
		[SerializeField] protected float coolDownTimeInSeconds;
		[SerializeField] protected float abilityDistance;
		[SerializeField] protected AudioClip soundEffect;
		[SerializeField] protected ParticleSystem visualEffect;

		public DamageType DamageType => damageType;
		public int DamageAmount => damageAmount;
		public int BloodCostAmount => bloodCostAmount;
		public float CoolDownTimeInSeconds => coolDownTimeInSeconds;
		public float AbilityDistance => abilityDistance;
		public AudioClip SoundEffect => soundEffect;
		public ParticleSystem VisualEffect => visualEffect;
	}
}