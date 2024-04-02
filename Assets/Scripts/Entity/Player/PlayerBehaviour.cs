using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using VartraAbyss.Utility;
using static VartraAbyss.Actions.Action;

namespace VartraAbyss.Entity.Player
{
	public class PlayerBehaviour : Actor
	{
		[SerializeField] private PlayerInput m_playerControl;

		[SerializeField] private int m_blood;
		[SerializeField] private int m_maximumBlood;

		private bool m_isSkillsMenuOpen;
		private GameObject m_skillToAbsorb;
		private Utility.Timer m_abilityTimer;

		private void Start()
		{
			m_isSkillsMenuOpen = false;
			m_skillToAbsorb = null;
			m_agent = GetComponent<NavMeshAgent>();
		}

		private void OnEnable()
		{
			m_playerControl.actions.FindAction("Primary").started += OnPrimaryInput;
			m_playerControl.actions.FindAction("Primary").performed += OnPrimaryInput;
			m_playerControl.actions.FindAction("Primary").canceled += OnPrimaryInput;
		}

		private void OnTriggerEnter(Collider other)
		{
			if ( other.CompareTag("AbilityToAbsorb") )
			{
				Debug.Log("Can Absorb Ability");
				EventManager.OnCanAbsorbAbility?.Invoke();
				m_skillToAbsorb = other.gameObject;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ( other.CompareTag("AbilityToAbsorb") )
			{
				Debug.Log("Cannot Absorb Ability");
				EventManager.OnCannotAbsorbAbility?.Invoke();
				m_skillToAbsorb = null;
			}
		}

		private void FixedUpdate()
		{
			switch ( CurrentAction )
			{
				case ActionTypes.Unset:
				{
					throw new System.Exception($"The {m_currentAction} on {gameObject.name} has not been set correctly. Please check the {ListOfActions} and ensure there are no errors.");
				}

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

					//else if(IsMoving && IsNotWithinRangeAndAttacking)
					//{
					//	m_currentAction = ActionTypes.CastAbility;
					//}
				}
				break;

				case ActionTypes.UseItem:
				{
					throw new System.Exception($"The {ActionTypes.UseItem} on {gameObject.name} has not been implemented yet.");
				}

				case ActionTypes.Interact:
				{
					throw new System.Exception($"The {ActionTypes.Interact} on {gameObject.name} has not been implemented yet.");
				}

				case ActionTypes.CastAbility:
				{
					if(m_abilityTimer == null)
					{
						m_abilityTimer = gameObject.AddComponent<Utility.Timer>();
						m_abilityTimer.SetTimer(CoolDownTimer);
					}

					if (m_abilityTimer.CurrentTime <= 0)
					{
						CastAbility();
						m_abilityTimer.ResetTimer();
						m_currentAction = ActionTypes.Idle;
					}					
				}
				break;

				case ActionTypes.Cancel:
				{
					m_currentAction = ActionTypes.Idle;
				}
				break;

				default:
				{
					return;
				}
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

		private void UseItem()
		{
			ListOfActions[ActionTypes.UseItem].PerformAction(this, CurrentItem);
		}

		private void Interact()
		{
			ListOfActions[ActionTypes.Interact].PerformAction(this, Target);
		}

		private void Cancel()
		{
			ListOfActions[ActionTypes.Cancel].PerformAction();
		}

		private bool CheckDistanceBetweenActors(GameObject actor1, GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1, actor2) > AbilityDistance;
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
						//if(CheckDistanceBetweenActors(gameObject, hit.collider.gameObject))
						//{
						//	m_isMoving = true;
						//	m_target = hit.collider.GetComponent<Enemy.EnemyBehaviour>();
						//	m_coolDownTimer = ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility);
						//	m_clickPoint = hit.point;
						//	m_isNotWithinRangeAndAttacking = true;
						//	m_currentAction = ActionTypes.Move;
						//}

						//TO DO: Check distance between player and enemy
						//If distance is too far, move towards enemy and use ability

						m_isMoving = false;
						m_target = hit.collider.GetComponent<Enemy.EnemyBehaviour>();
						m_coolDownTimer = ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility);
						m_currentAction = ActionTypes.CastAbility;
					}
					else
					{
						m_isMoving = true;
						m_clickPoint = hit.point;
						m_currentAction = ActionTypes.Move;
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
			if ( !m_isSkillsMenuOpen )
			{
				EventManager.OnSkillsMenu?.Invoke();
				m_isSkillsMenuOpen = true;
			}
			else if ( m_isSkillsMenuOpen )
			{
				EventManager.OnSkillsMenuClose?.Invoke();
				m_isSkillsMenuOpen = false;
			}
		}

		private void OnAbsorbAbility()
		{
			Destroy(m_skillToAbsorb);
			EventManager.OnCannotAbsorbAbility?.Invoke();
		}

	}
}