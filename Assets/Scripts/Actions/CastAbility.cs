using VartraAbyss.Items;
using VartraAbyss.Entity;
//using UnityEditor.Playables;
using VartraAbyss.Abilities;
using UnityEngine;

namespace VartraAbyss.Actions
{
	public class CastAbility : Action
	{
		public CastAbility()
		{
			m_actionType = ActionTypes.CastAbility;
		}

		public override DamageType GetDamageType(Ability abilityToCheck)
		{
			return abilityToCheck.DamageType;
		}

		public override int GetDamageAmount(Ability damageAmount)
		{
			return damageAmount.DamageAmount;
		}

		public override float GetCoolDownTimeInSeconds(Ability coolDownTimeInSeconds)
		{
			return coolDownTimeInSeconds.CoolDownTimeInSeconds;
		}

		public override void PerformAction(Actor self, Actor target)
		{
			target.Health -= GetDamageAmount(self.CurrentAbility);
		}

		public override void AddToQueue()
		{
			base.AddToQueue();
		}
	}
}