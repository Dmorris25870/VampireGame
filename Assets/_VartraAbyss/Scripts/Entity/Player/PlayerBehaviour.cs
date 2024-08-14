using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VartraAbyss.Abilities;
using VartraAbyss.Actions;
using VartraAbyss.Managers;
using VartraAbyss.PlayerInputs;
using VartraAbyss.Stats;

namespace VartraAbyss.Entity.Player
{
	[RequireComponent(typeof(PlayerInputController))]
	[RequireComponent(typeof(Stat))]
	[RequireComponent(typeof(NavMeshAgent))]
	public class PlayerBehaviour : Actor
	{
		[TabGroup("Actor" , "Actions" , SdfIconType.Activity , TextColor = "white")]
		private GameObject m_skillToAbsorb;
		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] private AbilitySO m_abilityData;
		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] private List<GameObject> m_abilitiesToSpawn = new();

		private void OnEnable()
		{
			Global.OnGetPlayerEvent += StoreActor;
			EventManager.OnReturnUsedAbility += SetCurrentAbility;
			SetupDependencies();
		}

		private void OnDisable()
		{
			Global.OnGetPlayerEvent -= StoreActor;
			EventManager.OnReturnUsedAbility -= SetCurrentAbility;
		}

		protected override Actor StoreActor()
		{
			return this;
		}

		//TO DO: Probably should put the responsibility of the ability pick up on the ability itself.

		private void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("AbilityToAbsorb"))
			{
				EventManager.OnCanAbsorbAbility?.Invoke();
				m_skillToAbsorb = other.gameObject;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if(other.CompareTag("AbilityToAbsorb"))
			{
				EventManager.OnCannotAbsorbAbility?.Invoke();
				m_skillToAbsorb = null;
			}
		}

		private void FixedUpdate()
		{
			if(ListOfActions.TryGetValue(CurrentAction , out Action action))
			{
				// 1st param is self, then a Vector, 
				action.Execute(this , Target);
			}

			if(Stat.Health <= 0)
			{
				EventManager.OnPlayerDeathEvent?.Invoke();
			}

		}

		private void SetupDependencies()
		{
			m_skillToAbsorb = null;
			base.SetCurrentAbility(null , "NullAbility");
			SetNavMeshAgent(GetComponent<NavMeshAgent>());
			SetStats(Stat);
			Stat.InitializeStats();
			EventManager.OnHealthChanged?.Invoke();
			EventManager.OnBloodChanged?.Invoke();
			SetCurrentAction(Action.ActionTypes.Idle);
			EventManager.OnLevelUpEvent?.Invoke(this);
		}

		public override void SetTarget(Vector3 newTarget)
		{
			base.SetTarget(newTarget);
		}

		public override void SetCurrentAbility(Ability ability , string abilityName)
		{
			base.SetCurrentAbility(ability , abilityName);
			if(Stat.Blood > 0)
			{
				UseCurrentAbility();
			}
		}

		private void UseCurrentAbility()
		{
			if(CurrentAbility is IAbility_Strategy strategy)
			{
				strategy.UseAbility(this);
			}

			base.SetCurrentAbility(null , "NullAbility");
		}
	}
}