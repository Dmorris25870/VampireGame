using System.Collections;
using System.Collections.Generic;
using VartaAbyss.Actions;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using AYellowpaper.SerializedCollections;
using VartaAbyss.Items;

namespace VartaAbyss.Entity.Player
{
	public class PlayerBehaviour : Actor
	{
		[SerializeField] PlayerInput playerControl;
		[SerializeField] NavMeshAgent agent;
		[SerializeField] private Action.ActionTypes m_currentAction;
		[SerializeField] private LayerMask m_ignorePlayerLayer;

		[SerializedDictionary("Action Name", "Action")]
		[SerializeField] SerializedDictionary<Action.ActionTypes, Action> m_listOfActions = new SerializedDictionary<Action.ActionTypes, Action>();

		private bool isMoving;
		private bool skillsMenuIsOpen;
		private GameObject skillToAbsorb;

		public Action.ActionTypes CurrentAction { get { return m_currentAction; } }

		void Start()
		{
			skillsMenuIsOpen = false;
			skillToAbsorb = null;
		}

		private void OnEnable()
		{
			playerControl.actions.FindAction("Primary").started += OnPrimaryInput;
			playerControl.actions.FindAction("Primary").performed += OnPrimaryInput;
			playerControl.actions.FindAction("Primary").canceled += OnPrimaryInput;
		}

		private void OnTriggerEnter(Collider other)
		{
			if ( other.CompareTag("AbilityToAbsorb") )
			{
				Debug.Log("Can Absorb Ability");
				EventManager.OnCanAbsorbAbility?.Invoke();
				skillToAbsorb = other.gameObject;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ( other.CompareTag("AbilityToAbsorb") )
			{
				Debug.Log("Cannot Absorb Ability");
				EventManager.OnCannotAbsorbAbility?.Invoke();
				skillToAbsorb = null;
			}
		}

		void FixedUpdate()
		{
			if ( isMoving )
			{
				MovePlayer();
			}
		}

		void MovePlayer()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			RaycastHit hit;
			if ( Physics.Raycast(ray, out hit, m_ignorePlayerLayer) )
			{
				if ( hit.collider.GetComponent<Enemy.EnemyBehaviour>() != null )
				{
					//TO DO: Check distance between self and target, move closer if far away, attack if close.

					m_listOfActions[CurrentAction].PerformAction(this, hit.collider.GetComponent<Actor>());
				}
				else
				{
					agent.SetDestination(hit.point);
				}

			}
		}

		void OnPrimaryInput(InputAction.CallbackContext context)
		{
			if ( context.performed || context.started )
			{
				isMoving = true;
			}
			if ( context.canceled )
			{
				isMoving = false;
			}
		}

		private void OnAbility1()
		{
			EventManager.OnQAbility?.Invoke();
		}

		private void OnAbility2()
		{
			EventManager.OnWAbility?.Invoke();
		}

		private void OnSkills()
		{
			Debug.Log("Skills Menu");
			if ( !skillsMenuIsOpen )
			{
				EventManager.OnSkillsMenu?.Invoke();
				skillsMenuIsOpen = true;
			}
			else if ( skillsMenuIsOpen )
			{
				EventManager.OnSkillsMenuClose?.Invoke();
				skillsMenuIsOpen = false;
			}
		}

		private void OnAbsorbAbility()
		{
			Destroy(skillToAbsorb);
			EventManager.OnCannotAbsorbAbility?.Invoke();
		}

	}
}