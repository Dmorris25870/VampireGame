using System.Collections;
using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Entity.Enemy;

namespace VartraAbyss.Abilities
{
	public class Claw : Ability, IAbility_Strategy
	{
		[SerializeField] private MeshRenderer m_mesh;
		[SerializeField] private MeleeSystem m_meleeSystem;
		[SerializeField] private Animator m_animator;

		public void UseAbility(Actor self)
		{
			m_animator.Play("ClawAnim");
			if( m_meleeSystem.Target != null && m_meleeSystem.Target != self )
			{
				if (m_meleeSystem.Target.tag == "Player")
				{
					m_meleeSystem.Target.Stat.ModifyHealth(-AbilityData.damage);
				}

				if (m_meleeSystem.Target.tag == "Enemy")
				{
					m_meleeSystem.Target.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(-AbilityData.damage);
				}
				//m_meleeSystem.Target.Stat.ModifyHealth(-AbilityData.damage);				
				//StartCoroutine(ToggleMeshRenderer());
			}
			
		}

		private IEnumerator ToggleMeshRenderer()
		{
			m_mesh.enabled = true;
			yield return new WaitForSeconds(0.2f);
			m_mesh.enabled = false;
		}
	}
}