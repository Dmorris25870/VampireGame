using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using VartraAbyss.Utility;
using VartraAbyss.Stats;
using static VartraAbyss.Actions.Action;

namespace VartraAbyss.Entity.Player
{
	public class PlayerBehaviour : Actor
	{
		[TabGroup("Actor" , "Components" , SdfIconType.ExclamationTriangle , TextColor = "red")]
		[Required]
		[SerializeField] private PlayerInput playerControl;

		[TabGroup("Actor" , "Items" , SdfIconType.Grid , TextColor = "cyan")]
		[TableMatrix(HorizontalTitle = "Inventory" , SquareCells = true)]
		public ItemBehaviour[,] inventory;

		private ActionQueue actionQueue;
		private bool isSkillsMenuOpen;
		private GameObject skillToAbsorb;
		private Timer abilityTimer;

		private void Start()
		{
			isSkillsMenuOpen = false;
			skillToAbsorb = null;
			agent = GetComponent<NavMeshAgent>();
		}

		[OnInspectorInit]
		private void CreateData()
		{
			inventory = new ItemBehaviour[8 , 4]
			{
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
				{ null, null, null, null },
			};
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
				EventManager.OnCanAbsorbAbility?.Invoke();
				skillToAbsorb = other.gameObject;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if ( other.CompareTag("AbilityToAbsorb") )
			{
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
					throw new System.Exception($"The Current Action on {gameObject.name} has not been set correctly. Please check the List of Actions and ensure there are no errors.");
				}

				case ActionTypes.Idle:
				{
					return;
				}

				case ActionTypes.Move:
				{
					if ( IsMoving )
					{
						MovePlayer();
					}
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
					if ( abilityTimer == null )
					{
						abilityTimer = gameObject.AddComponent<Timer>();
						abilityTimer.SetTimer(ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility));
					}

					if ( abilityTimer.CurrentTime <= 0 )
					{
						CastAbility();
						abilityTimer.ResetTimer();
						currentAction = ActionTypes.Idle;
					}
				}
				break;

				case ActionTypes.Cancel:
				{
					currentAction = ActionTypes.Idle;
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

		private void Idle()
		{
			ListOfActions[ActionTypes.Idle].PerformAction();
		}

		private void Cancel()
		{
			ListOfActions[ActionTypes.Cancel].PerformAction();
		}

		private bool IsWithinAbilityRange(GameObject actor1, GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1, actor2) > CurrentAbility.AbilityDistance;
		}

		private void OnPrimaryInput(InputAction.CallbackContext context)
		{
			if ( context.performed || context.started )
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if( Physics.Raycast(ray , out RaycastHit hit , IgnorePlayerLayer) )
				{
					clickPoint = hit.point;

					if( hit.collider.GetComponent<Enemy.EnemyBehaviour>() != null )
					{
						target = hit.collider.GetComponent<Enemy.EnemyBehaviour>();

						if( IsWithinAbilityRange(gameObject , hit.collider.gameObject) )
						{
							isMoving = true;
							isAttacking = true;
							currentAction = ActionTypes.Move;
						}
						else
						{
							isMoving = false;
							currentAction = ActionTypes.CastAbility;
						}
					}
					else
					{
						isMoving = true;
						currentAction = ActionTypes.Move;
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
			if ( !isSkillsMenuOpen )
			{
				EventManager.OnSkillsMenu?.Invoke();
				isSkillsMenuOpen = true;
			}
			else if ( isSkillsMenuOpen )
			{
				EventManager.OnSkillsMenuClose?.Invoke();
				isSkillsMenuOpen = false;
			}
		}

		private void OnAbsorbAbility()
		{
			Destroy(skillToAbsorb);
			EventManager.OnCannotAbsorbAbility?.Invoke();
		}
	}
}