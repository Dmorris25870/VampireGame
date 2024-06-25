using System.Collections;
using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Bite : Ability, IAbility_Strategy
	{
		[SerializeField] private Collider m_collider;
		private bool m_hasHitTarget = false;

		public void UseAbility(Actor self)
		{
			m_collider = self.GetComponentInChildren<Spawner>().GetComponent<Collider>();
			m_collider.enabled = true;
			m_hasHitTarget = false;
			StartCoroutine(ActivateTriggerVolume());

			if( m_hasHitTarget )
			{
				self.Stat.ModifyBlood(AbilityData.damage);
			}
		}

		IEnumerator ActivateTriggerVolume()
		{
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
					m_hasHitTarget = true;
				}
			}
		}
	}
}