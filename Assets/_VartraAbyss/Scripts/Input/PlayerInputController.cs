using UnityEngine;
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

		private Vector3 m_clickPoint;
		public LayerMask IgnorePlayerLayer => m_ignorePlayerLayer;
		public Vector3 ClickPoint { get => m_clickPoint; set => m_clickPoint = value; }
		public PlayerInput PlayerControl => m_playerControl;
		public PlayerBehaviour Player => m_player;

		public delegate Vector3 PlayerClickEvent();
		public static PlayerClickEvent OnPlayerClick;
		private bool m_toggleSkillMenu;

		private void OnEnable()
		{
			m_playerControl.actions.FindAction("Primary").performed += OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("HealthPotion").performed += OnAbilityOnePressed;
			m_playerControl.actions.FindAction("ManaPotion").performed += OnAbilityTwoPressed;
			m_playerControl.actions.FindAction("Ability1").performed += OnAbilityThreePressed;
			m_playerControl.actions.FindAction("Ability2").performed += OnAbilityFourPressed;
			m_playerControl.actions.FindAction("Ability3").performed += OnAbilityFivePressed;
			m_playerControl.actions.FindAction("Ability4").performed += OnAbilitySixPressed;
			m_playerControl.actions.FindAction("Ability5").performed += OnAbilitySevenPressed;
			m_playerControl.actions.FindAction("Skills").performed += OnSkillsMenuPressed;
			OnPlayerClick += OnPrimaryInput;
		}

		private void OnDisable()
		{
			m_playerControl.actions.FindAction("Primary").performed -= OnPrimaryInputCommand;
			m_playerControl.actions.FindAction("HealthPotion").performed -= OnAbilityOnePressed;
			m_playerControl.actions.FindAction("ManaPotion").performed -= OnAbilityTwoPressed;
			m_playerControl.actions.FindAction("Ability1").performed -= OnAbilityThreePressed;
			m_playerControl.actions.FindAction("Ability2").performed -= OnAbilityFourPressed;
			m_playerControl.actions.FindAction("Ability3").performed -= OnAbilityFivePressed;
			m_playerControl.actions.FindAction("Ability4").performed -= OnAbilitySixPressed;
			m_playerControl.actions.FindAction("Ability5").performed -= OnAbilitySevenPressed;
			m_playerControl.actions.FindAction("Skills").performed -= OnSkillsMenuPressed;
			OnPlayerClick -= OnPrimaryInput;
		}

		private bool IsWithinAbilityRange(Actor actor1 , GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1.gameObject , actor2) > actor1.CurrentAbility.Range;
		}

		private void OnPrimaryInputCommand(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				if( Utilities.IsPointerOverUIElement() )
				{
					return;
				}
				else
				{
					OnPrimaryInput();
				}
			}
		}

		private void OnAbilityOnePressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot1Ability?.Invoke();
				Debug.Log("1 Button has been pressed and Invoked.");
			}
		}

		private void OnAbilityTwoPressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot2Ability?.Invoke();
				Debug.Log("2 Button has been pressed and Invoked.");
			}
		}

		private void OnAbilityThreePressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot3Ability?.Invoke();
				Debug.Log("Q Button has been pressed and Invoked.");
			}
		}

		private void OnAbilityFourPressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot4Ability?.Invoke();
				Debug.Log("W Button has been pressed and Invoked.");
			}
		}

		private void OnAbilityFivePressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot5Ability?.Invoke();
				Debug.Log("E Button has been pressed and Invoked.");
			}
		}

		private void OnAbilitySixPressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot6Ability?.Invoke();
				Debug.Log("R Button has been pressed and Invoked.");
			}
		}

		private void OnAbilitySevenPressed(InputAction.CallbackContext context)
		{
			if( context.performed )
			{
				EventManager.OnActivatedSlot7Ability?.Invoke();
				Debug.Log("T Button has been pressed and Invoked.");
			}
		}

		private void OnSkillsMenuPressed(InputAction.CallbackContext context)
		{
			m_toggleSkillMenu = !m_toggleSkillMenu;

			if( context.performed )
			{
				if( m_toggleSkillMenu )
				{
					EventManager.OnSkillsMenu?.Invoke();
					Debug.Log("S Button has been pressed and Invoked.");
				}
				else
				{
					EventManager.OnSkillsMenuClose?.Invoke();
					Debug.Log("S Button has been pressed and Invoked.");
				}
			}
		}

		private Vector3 OnPrimaryInput()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Actor player = Global.OnGetPlayerEvent?.Invoke();

			if( Physics.Raycast(ray , out RaycastHit hit , IgnorePlayerLayer) )
			{
				player.SetTarget(hit.point);

				if( hit.collider.GetComponent<Entity.Enemy.EnemyBehaviour>() != null )
				{
					player.SetTarget(hit.collider.GetComponent<Entity.Enemy.EnemyBehaviour>().transform.position);

					if( IsWithinAbilityRange(gameObject.GetComponent<Actor>() , hit.collider.gameObject) )
					{
						player.SetIsMoving(true);
						player.SetIsAttacking(true);
						player.SetCurrentAction(ActionTypes.Move);
						return player.Target;
					}
					else
					{
						player.SetIsMoving(false);
						// CAST ABILITY?
						return player.Target;
					}
				}
				else
				{
					player.SetIsMoving(true);
					player.SetCurrentAction(ActionTypes.Move);
					return player.Target;
				}
			}

			return player.Target;
		}
	}
}