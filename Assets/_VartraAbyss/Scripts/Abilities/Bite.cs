using System.Collections;
using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Bite : Ability, IAbility_Strategy
	{
		[SerializeField] private Collider m_collider;

		public void UseAbility(Actor self)
		{
			m_collider = self.GetComponentInChildren<Spawner>().GetComponent<Collider>();

			if( this == enabled )
			{
				StartCoroutine(ActivateTriggerVolume());
			}

			self.Stat.ModifyBlood(AbilityData.damage);
		}

		IEnumerator ActivateTriggerVolume()
		{
			m_collider.enabled = true;

			yield return new WaitForSeconds(AbilityData.coolDownTime);

			m_collider.enabled = false;
		}

		void OnTriggerEnter(Collider other)
		{
			if( other != m_collider )
			{
				if( other.gameObject.GetComponent<Actor>() != null )
				{
					Actor target = other.gameObject.GetComponent<Actor>();
					target.Stat.ModifyHealth(-AbilityData.damage);
				}
			}
		}
	}
}