using VartaAbyss.Items;
using VartaAbyss.Entity;
using UnityEditor.Playables;
using VartaAbyss.Abilities;
using UnityEngine;

namespace VartaAbyss.Actions
{
	public class CastAbility : Action
	{
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