using System.Collections;
using System.Collections.Generic;
using VartaAbyss.Actions;
using VartaAbyss.Items;
using VartaAbyss.Utility;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using AYellowpaper.SerializedCollections;
using static VartaAbyss.Actions.Action;

namespace VartaAbyss.Entity.Player
{
	public class PlayerBehaviour : Actor
	{
		[SerializeField] private PlayerInput playerControl;	

		public int blood;
		public int maxBlood;

		private bool skillsMenuIsOpen;
		private GameObject skillToAbsorb;

		private void Start()
		{
			skillsMenuIsOpen = false;
			skillToAbsorb = null;
			CurrentTimer = 0;
			Agent = GetComponent<NavMeshAgent>();
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

		private void FixedUpdate()
		{
			switch ( CurrentAction )
			{
				case ActionTypes.Unset:
				{

				}
				break;

				case ActionTypes.Idle:
				{
					return;
				}

				case ActionTypes.Move:
				{
					if(IsMoving)
					{
						MovePlayer();
					}
				}
				break;

				case ActionTypes.UseItem:
				{

				}
				break;

				case ActionTypes.Interact:
				{

				}
				break;

				case ActionTypes.CastAbility:
				{
					if (CurrentTimer <= 0)
					{
						CastAbility();
						CurrentTimer = CoolDownTimer;
					}
					else
					{
						CurrentTimer -= Time.deltaTime;
					}
					
				}
				break;

				case ActionTypes.Cancel:
				{

				}
				break;

				default:
				{

				}
				break;
			}
		}

		private void MovePlayer()
		{
			ListOfActions[ActionTypes.Move].PerformAction(this);
		}

		private void CastAbility()
		{
			ListOfActions[ActionTypes.CastAbility].PerformAction(this, Target);
		}

		private void OnPrimaryInput(InputAction.CallbackContext context)
		{
			if ( context.performed || context.started )
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				RaycastHit hit;
				if ( Physics.Raycast(ray, out hit, IgnorePlayerLayer) )
				{
					if ( hit.collider.GetComponent<Enemy.EnemyBehaviour>() != null )
					{
						//TO DO: Check distance between player and enemy
						//If distance is too far, move towards enemy and use ability

						IsMoving = false;
						Target = hit.collider.GetComponent<Enemy.EnemyBehaviour>();
						CoolDownTimer = ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility);
						CurrentAction = ActionTypes.CastAbility;
					}
					else
					{
						IsMoving = true;
						ClickPoint = hit.point;
						CurrentAction = ActionTypes.Move;
					}
				}
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