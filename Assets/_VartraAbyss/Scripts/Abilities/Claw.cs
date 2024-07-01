using System.Collections;
using UnityEngine;
using VartraAbyss.Entity;

namespace VartraAbyss.Abilities
{
	public class Claw : Ability, IAbility_Strategy
	{
		[SerializeField] private Collider m_collider;
		[SerializeField] private MeshRenderer m_mesh;

		public void UseAbility(Actor self)
		{
			m_collider = self.GetComponentInChildren<Spawner>().GetComponent<Collider>();
			m_mesh = self.GetComponentInChildren<Spawner>().GetComponent<MeshRenderer>();
			m_collider.enabled = true;
			m_mesh.enabled = true;
			StartCoroutine(ActivateTriggerVolume());
			self.Stat.ModifyBlood(-AbilityData.bloodCost);
		}

		IEnumerator ActivateTriggerVolume()
		{
			yield return new WaitForSeconds(0.1f);
			m_collider.enabled = false;
			m_mesh.enabled = false;
			yield return new WaitForSeconds(AbilityData.coolDownTime);
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