using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class HealthPotion : Ability, IAbility_Strategy
	{
		[field: SerializeField] public int PotionUsesRemaining { get; private set; }
		[field: SerializeField] public int HealingAmount { get; private set; }

		private void Awake()
		{
			SetPotionUses(AbilityData.potionUsesRemaining);
		}

		public void SetPotionUses(int amount)
		{
			PotionUsesRemaining = amount;
		}

		public void SetHealingAmount(int amount)
		{
			HealingAmount = amount;
		}

		public void ModifyPotionUses(int amount)
		{
			PotionUsesRemaining += amount;
		}

		public void UseAbility(Actor self)
		{
			if( PotionUsesRemaining == 0 )
			{
				return;
			}
			else
			{
				PotionUsesRemaining--;
				self.Stat.ModifyHealth(HealingAmount);
			}
		}
	}
}
