using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Managers;

namespace VartraAbyss.Abilities
{
	public class HealthPotion : Ability, IAbility_Strategy
	{
		[field: SerializeField] public float HealingAmount { get; private set; }
		[field: SerializeField] public float PercentageToHeal { get; private set; }

		private void Start()
		{
			SetHealingAmount(Global.OnGetPlayerEvent?.Invoke() , PercentageToHeal);
		}

		public void SetHealingAmount(Actor self , float percentage)
		{

			HealingAmount = self.Stat.MaximumHealth * percentage;
		}

		public void UseAbility(Actor self)
		{
			self.Stat.ModifyHealth(HealingAmount);
		}
	}
}
