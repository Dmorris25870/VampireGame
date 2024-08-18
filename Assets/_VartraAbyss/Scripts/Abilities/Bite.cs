using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Entity.Enemy;

namespace VartraAbyss.Abilities
{
	public class Bite : Ability, IAbility_Strategy
	{
		[SerializeField] private MeleeSystem m_meleeSystem;
		[SerializeField] private Animator m_animator;

		private void OnEnable()
		{
			m_meleeSystem.GetComponentInChildren<MeleeSystem>();
		}

		private void OnDisable()
		{
			m_meleeSystem = null;
			m_animator = null;
		}

		public void UseAbility(Actor self)
		{
			Debug.Log(m_animator.ToString());
			m_animator.Play("BiteAnim");
			if(m_meleeSystem.Target != null && m_meleeSystem.Target != self)
			{
				self.Stat.ModifyBlood(AbilityData.damage);
				if(m_meleeSystem.Target.tag == "Player")
				{
					m_meleeSystem.Target.Stat.ModifyHealth(-AbilityData.damage);
				}

				if(m_meleeSystem.Target.tag == "Enemy")
				{
					m_meleeSystem.Target.gameObject.GetComponent<EnemyBehaviour>().TakeDamage(-AbilityData.damage);
				}
			}

		}
	}
}