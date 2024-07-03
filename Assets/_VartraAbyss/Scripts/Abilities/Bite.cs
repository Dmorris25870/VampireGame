using System.Collections;
using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Entity.Enemy;

namespace VartraAbyss.Abilities
{
	public class Bite : Ability, IAbility_Strategy
	{
		[SerializeField] private Collider m_collider;
		[SerializeField] private MeshRenderer m_mesh;
		private bool m_hasHitTarget = false;
		bool m_isRunning;

		public void UseAbility(Actor self)
		{
			m_collider = self.GetComponentInChildren<Spawner>().GetComponent<Collider>();
			m_mesh = self.GetComponentInChildren<Spawner>().GetComponent<MeshRenderer>();
			m_collider.enabled = true;
			m_mesh.enabled = true;
			m_hasHitTarget = false;

			if( !m_isRunning )
			{
				StartCoroutine(ActivateTriggerVolume());
			}

			if( m_hasHitTarget )
			{
				self.Stat.ModifyBlood(AbilityData.damage);
			}
		}

		IEnumerator ActivateTriggerVolume()
		{
			m_isRunning = true;
			m_collider.enabled = true;
			yield return new WaitForSeconds(0.1f);
			m_collider.enabled = false;
			m_isRunning = false;
			m_mesh.enabled = false;
		}

		void OnTriggerStay(Collider other)
		{
			if( m_isRunning )
			{
				if( other != m_collider )
				{
					if( other.gameObject.GetComponent<Actor>() != null && !gameObject.GetComponentInParent<EnemyBehaviour>() )
					{
						Actor target = other.gameObject.GetComponent<Actor>();
						target.Stat.ModifyHealth(-AbilityData.damage);
						m_hasHitTarget = true;
					}
				}
			}
		}
	}
}