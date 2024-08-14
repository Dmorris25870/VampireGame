using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class BloodPotion : Ability, IAbility_Strategy
	{
		[field: SerializeField] public int HealingAmount { get; private set; }

		public void SetHealingAmount(int amount)
		{
			HealingAmount = amount;
		}

		public void UseAbility(Actor self)
		{
			self.Stat.ModifyBlood(HealingAmount);
		}
	}
}
