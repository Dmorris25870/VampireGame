using System.Collections;
using System.Collections.Generic;
using VartaAbyss.Items;
using VartaAbyss.Entity;
using UnityEngine;
using VartaAbyss.Entity.Enemy;

namespace VartaAbyss.Actions
{
	public class Attack : Action
	{
		private Actor m_target;
		private bool m_isCurrentlyAttacking;

		public Actor Target { get { return m_target; } }

		private DamageType GetDamageType(Weapon weaponToCheck)
		{
			return weaponToCheck.DamageType;
		}

		private int GetDamageAmount(Weapon damage)
		{
			return damage.DamageAmount;
		}

		public override void PerformAttack(Actor self, Actor target)
		{
			m_isCurrentlyAttacking = true;
			//target.Health -= GetDamageAmount(self.CurrentSelectedWeapon.DamageAmount);
			m_isCurrentlyAttacking = false;
		}

		public override void AddToQueue()
		{
			base.AddToQueue();
		}
	}
}