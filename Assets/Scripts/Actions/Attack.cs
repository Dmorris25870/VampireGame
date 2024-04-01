using VartaAbyss.Items;
using VartaAbyss.Entity;
using UnityEditor.Playables;
using VartaAbyss.Abilities;

namespace VartaAbyss.Actions
{
	public class Attack : Action
	{
		private DamageType GetDamageType(Ability weaponToCheck)
		{
			return weaponToCheck.DamageType;
		}

		private int GetDamageAmount(Ability damage)
		{
			return damage.DamageAmount;
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