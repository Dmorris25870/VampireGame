using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Managers;

namespace VartraAbyss.Abilities
{
	public class HealthPotion : Ability, IAbility_Strategy
	{
		[field: SerializeField] public float HealingAmount { get; private set; }
		[field: SerializeField] public float PercentageToHeal { get; private set; }

		public void SetHealingAmount(Actor self , float percentage)
		{
			HealingAmount = self.Stat.MaximumHealth * percentage;
		}

		public void UseAbility(Actor self)
		{
			self.GetComponent<AudioSource>().PlayOneShot(SoundEffect);
			SetHealingAmount(Global.OnGetPlayerEvent?.Invoke() , PercentageToHeal);
			self.Stat.ModifyHealth(HealingAmount);
		}
	}
}
