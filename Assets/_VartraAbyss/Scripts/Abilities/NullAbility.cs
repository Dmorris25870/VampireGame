using UnityEngine;
using VartraAbyss.Abilities;
using VartraAbyss.Entity;

namespace VartraAbyss
{
	public class NullAbility : Ability, IAbility_Strategy
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
			m_animator.StopPlayback();
			//No ability
		}
	}
}
