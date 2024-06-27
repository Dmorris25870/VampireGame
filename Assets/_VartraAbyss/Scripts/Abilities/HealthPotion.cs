using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class HealthPotion : Ability, IAbility_Strategy
	{
		[field: SerializeField] public int PotionUses { get; private set; }
		[field: SerializeField] public int PotionCurrentRemaining { get; private set; }
		[field: SerializeField] public int HealingAmount { get; private set; }

		private void Start()
		{
			Refresh();
			SetPotionUses(PotionCurrentRemaining);
		}

		private void Refresh()
		{
			PotionCurrentRemaining = PotionUses;
		}

		public void SetPotionUses(int amount)
		{
			PotionUses = amount;
		}

		public void SetHealingAmount(int amount)
		{
			HealingAmount = amount;
		}

		public void ModifyPotionUses(int amount)
		{
			PotionCurrentRemaining += amount;
		}

		public void UseAbility(Actor self)
		{
			if( PotionCurrentRemaining == 0 )
			{
				return;
			}
			else
			{
				PotionCurrentRemaining--;
				self.Stat.ModifyHealth(HealingAmount);
			}
		}
	}
}
