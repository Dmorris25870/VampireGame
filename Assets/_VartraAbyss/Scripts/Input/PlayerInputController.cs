using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using VartraAbyss.Entity;
using VartraAbyss.Entity.Player;
using VartraAbyss.Managers;
using VartraAbyss.Utility;
using static VartraAbyss.Actions.Action;


namespace VartraAbyss.PlayerInputs
{
	public class PlayerInputController : MonoBehaviour
	{
		[SerializeField] private PlayerInput m_playerControl;
		[SerializeField] private PlayerBehaviour m_player;
		[SerializeField] private LayerMask m_ignorePlayerLayer;
		[SerializeField] private LayerMask m_interactionLayers;
		[SerializeField] public PlayerAnimations playerAnimations;
		[SerializeField] private Animator m_animator;

		private Camera m_mainCamera;
		private Vector3 m_clickPoint;
		public LayerMask IgnorePlayerLayer => m_ignorePlayerLayer;
		public Vector3 ClickPoint { get => m_clickPoint; set => m_clickPoint = value; }
		public PlayerInput PlayerControl => m_playerControl;
		public PlayerBehaviour Player => m_player;

		public delegate Vector3 PlayerClickEvent();
		public static PlayerClickEvent OnPlayerClick;
		private bool m_toggleSkillMenu;
		private bool m_togglePauseMenu;
		public bool isMoving;

		private void OnEnable()
		{
			m_playerControl.actions.FindAction("Primary").performed += OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("Primary").canceled += OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("HealthPotion").performed += OnAbilityOnePressed;
			m_playerControl.actions.FindAction("ManaPotion").performed += OnAbilityTwoPressed;
			m_playerControl.actions.FindAction("Ability1").performed += OnAbilityThreePressed;
			m_playerControl.actions.FindAction("Ability2").performed += OnAbilityFourPressed;
			m_playerControl.actions.FindAction("Ability3").performed += OnAbilityFivePressed;
			m_playerControl.actions.FindAction("Ability4").performed += OnAbilitySixPressed;
			m_playerControl.actions.FindAction("Ability5").performed += OnAbilitySevenPressed;
			m_playerControl.actions.FindAction("Skills").performed += OnSkillsMenuPressed;
			m_playerControl.actions.FindAction("Pause").performed += OnPauseMenuPressed;
			OnPlayerClick += OnPrimaryInput;
			m_playerControl.actions.FindAction("DebugMode").performed += OnDebugCommmand;
		}

		private void OnDisable()
		{
			m_playerControl.actions.FindAction("Primary").performed -= OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("Primary").canceled -= OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("HealthPotion").performed -= OnAbilityOnePressed;
			m_playerControl.actions.FindAction("ManaPotion").performed -= OnAbilityTwoPressed;
			m_playerControl.actions.FindAction("Ability1").performed -= OnAbilityThreePressed;
			m_playerControl.actions.FindAction("Ability2").performed -= OnAbilityFourPressed;
			m_playerControl.actions.FindAction("Ability3").performed -= OnAbilityFivePressed;
			m_playerControl.actions.FindAction("Ability4").performed -= OnAbilitySixPressed;
			m_playerControl.actions.FindAction("Ability5").performed -= OnAbilitySevenPressed;
			m_playerControl.actions.FindAction("Skills").performed -= OnSkillsMenuPressed;
			m_playerControl.actions.FindAction("Pause").performed -= OnPauseMenuPressed;
			OnPlayerClick -= OnPrimaryInput;
			m_playerControl.actions.FindAction("DebugMode").performed -= OnDebugCommmand;
		}

		void Start()
		{
			m_mainCamera = Camera.main;
		}

		private bool IsWithinAbilityRange(Actor actor1 , GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1.gameObject , actor2) > actor1.CurrentAbility.Range;
		}

		private void OnDebugCommmand(InputAction.CallbackContext context)
		{
			EventManager.OnDebugModeCommand?.Invoke();
		}

		private void OnPrimaryInputCommand(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				if(Utilities.IsPointerOverUIElement())
				{
					return;
				}
				else
				{
					isMoving = true;
				}
			}
			else if(context.canceled)
			{
				isMoving = false;
			}
		}

		private void OnAbilityOnePressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot1Ability?.Invoke();
			}
		}

		private void OnAbilityTwoPressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot2Ability?.Invoke();
			}
		}

		private void OnAbilityThreePressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot3Ability?.Invoke();
			}
		}

		private void OnAbilityFourPressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot4Ability?.Invoke();
			}
		}

		private void OnAbilityFivePressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot5Ability?.Invoke();
			}
		}

		private void OnAbilitySixPressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot6Ability?.Invoke();
			}
		}

		private void OnAbilitySevenPressed(InputAction.CallbackContext context)
		{
			if(context.performed)
			{
				EventManager.OnActivatedSlot7Ability?.Invoke();
			}
		}

		private void OnSkillsMenuPressed(InputAction.CallbackContext context)
		{
			m_toggleSkillMenu = !m_toggleSkillMenu;

			if(context.performed)
			{
				if(m_toggleSkillMenu)
				{
					EventManager.OnSkillsMenu?.Invoke();
				}
				else
				{
					EventManager.OnSkillsMenuClose?.Invoke();
				}
			}
		}

		private void OnPauseMenuPressed(InputAction.CallbackContext context)
		{
			m_togglePauseMenu = !m_togglePauseMenu;

			if(context.performed)
			{
				if(m_togglePauseMenu)
				{
					EventManager.OnGamePaused?.Invoke();
				}
				else
				{
					EventManager.OnGameUnpaused?.Invoke();
				}
			}
		}

		private void FixedUpdate()
		{
			if(isMoving)
			{
				OnPrimaryInput();
			}
		}
		private Vector3 OnPrimaryInput()
		{
			Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray , out RaycastHit hit , Mathf.Infinity , m_interactionLayers))
			{
				NavMeshHit navMeshHit;
				if(NavMesh.SamplePosition(hit.point , out navMeshHit , 1.0f , NavMesh.AllAreas))
				{
					Vector3 targetPosition = navMeshHit.position;
					Actor player = Global.OnGetPlayerEvent?.Invoke();
					if(player == null)
						return Vector3.zero;

					// Check if hit object is an enemy
					var enemyBehaviour = hit.collider.GetComponent<Entity.Enemy.EnemyBehaviour>();
					if(enemyBehaviour != null)
					{
						Vector3 enemyPosition = enemyBehaviour.transform.position;
						player.SetTarget(enemyPosition);

						bool isInRange = IsWithinAbilityRange(gameObject.GetComponent<Actor>() , hit.collider.gameObject);
						player.SetIsMoving(true);
						m_animator.SetBool("isMoving" , true);
						player.SetIsAttacking(isInRange);
						player.SetCurrentAction(ActionTypes.Move);
						return player.Target;
					}
					else
					{
						player.SetTarget(targetPosition);
						player.SetIsMoving(true);
						m_animator.SetBool("isMoving" , true);
						player.SetCurrentAction(ActionTypes.Move);
						return player.Target;
					}
				}
			}

			// Default action when nothing is hit
			Actor defaultPlayer = Global.OnGetPlayerEvent?.Invoke();

			if(defaultPlayer != null)
			{
				defaultPlayer.SetIsMoving(false);
			}
			return Vector3.zero;
		}
	}
}