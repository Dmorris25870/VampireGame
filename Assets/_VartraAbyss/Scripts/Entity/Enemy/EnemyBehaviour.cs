using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VartraAbyss.Abilities;
using VartraAbyss.Actions;
using VartraAbyss.Entity.Player;
using VartraAbyss.Utility;
using static VartraAbyss.Actions.Action;

namespace VartraAbyss.Entity.Enemy
{
	public class EnemyBehaviour : Actor
	{
		[SerializeField] private List<ItemBase> itemsList = new();
		[SerializeField] private EnemyBase enemyBase;
		[SerializeField] private GameObject itemObject;
		[SerializeField] private GameObject goldObject;
		[SerializeField] private float baseGold;
		[SerializeField] public int enemyHealth;
		[SerializeField] private Timer attackTimer;
		private PlayerBehaviour playerBehaviour;
		public GameObject player;
		public bool isAggroed;
		private float aggroRange;

		private void Start()
		{
			SetupActions();
			enemyHealth = enemyBase.enemyHealth;
			aggroRange = enemyBase.aggroRange;
			player = GameObject.FindGameObjectWithTag("Player");
			playerBehaviour = player.GetComponent<PlayerBehaviour>();
			SetNavMeshAgent(GetComponent<NavMeshAgent>());
			SetCurrentAbility(null , "Bite");
		}

		private void DropItems()
		{
			for( int i = 0; i < enemyBase.lootTable.items.Length; i++ )
			{
				for( int j = 0; j < enemyBase.lootTable.items[i].itemWeight; j++ )
				{
					if( enemyBase.lootTable.items[i] != null )
					{
						itemsList.Add(enemyBase.lootTable.items[i]);
					}
				}
			}

			for( int i = 0; i < enemyBase.itemDrops; i++ )
			{
				GameObject instantiatedItem = Instantiate(itemObject);
				instantiatedItem.GetComponent<ItemBehaviour>().itemBase = itemsList[Random.Range(0 , itemsList.Count)];
				instantiatedItem.GetComponent<ItemBehaviour>().SpawnItem();
			}

			GameObject instantiatedGold = Instantiate(goldObject);
			instantiatedGold.GetComponent<GoldBase>().goldValue = baseGold * Random.Range(0.8f , 1.2f);
			instantiatedGold.GetComponent<GoldBase>().goldText.text = baseGold + " Gold";
		}

		public void TakeDamage(int damage)
		{
			if( enemyHealth <= 0 )
			{
				Die();
			}
		}
		public override void Die()
		{
			DropItems();
		}

		private void FixedUpdate()
		{
			if( IsWithinAggroRange(gameObject , player) )
			{
				SetTarget(player.transform.position);
				if( IsWithinAbilityRange(gameObject , player) )
				{
					SetIsMoving(true);
					SetIsAttacking(true);
					SetCurrentAction(ActionTypes.Move);
				}
				else
				{
					SetIsMoving(false);
					SetCurrentAction(ActionTypes.CastAbility);
				}
			}

			if( ListOfActions.TryGetValue(CurrentAction , out Action action) )
			{
				// 1st param is self, then a Vector, 
				action.Execute(this , Target);
			}


			//switch( CurrentAction )
			//{
			//	case ActionTypes.Unset:
			//	{
			//		throw new System.Exception($"The Current Action on {gameObject.name} has not been set correctly. Please check the List of Actions and ensure there are no errors.");
			//	}

			//	case ActionTypes.Idle:
			//	{
			//		return;
			//	}

			//	case ActionTypes.Move:
			//	{
			//		if( IsMoving )
			//		{
			//			MoveEnemy();
			//		}
			//	}
			//	break;

			//	case ActionTypes.UseItem:
			//	{
			//		throw new System.Exception($"The {ActionTypes.UseItem} on {gameObject.name} has not been implemented yet.");
			//	}

			//	case ActionTypes.Interact:
			//	{
			//		throw new System.Exception($"The {ActionTypes.Interact} on {gameObject.name} has not been implemented yet.");
			//	}

			//	case ActionTypes.CastAbility:
			//	{
			//		if( attackTimer == null )
			//		{
			//			attackTimer = gameObject.AddComponent<Timer>();
			//			attackTimer.SetTimer(ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility));
			//		}

			//		if( attackTimer.CurrentTime <= 0 )
			//		{
			//			CastAbility();
			//			attackTimer.ResetTimer();
			//			currentAction = ActionTypes.Idle;
			//		}
			//	}
			//	break;

			//	case ActionTypes.Cancel:
			//	{
			//		currentAction = ActionTypes.Idle;
			//	}
			//	break;

			//	default:
			//	{
			//		return;
			//	}
			//}
		}

		//private void MoveEnemy()
		//{
		//	ListOfActions[ActionTypes.Move].PerformAction(this);
		//}

		//private void CastAbility()
		//{
		//	ListOfActions[ActionTypes.CastAbility].PerformAction(this , Target);
		//}
		private bool IsWithinAbilityRange(GameObject actor1 , GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1 , actor2) > CurrentAbility.Range;
		}

		private bool IsWithinAggroRange(GameObject actor1 , GameObject actor2)
		{
			return Utilities.GetDistanceBetweenTwoActors(actor1 , actor2) < aggroRange;
		}

		private void SetupActions()
		{
			GameObject actions = new("EnemyActions");
			actions.transform.SetParent(this.transform);
			ListOfActions = new SerializedDictionary<ActionTypes , Action>
			{
				{ ActionTypes.Idle , actions.AddComponent<Idle>() } ,
				{ ActionTypes.Move , actions.AddComponent<Move>() } ,
				{ ActionTypes.CastAbility , actions.AddComponent<CastAbility>() }
			};

			SetCurrentAction(ActionTypes.Idle);
		}

		public override void SetCurrentAbility(Ability ability , string abilityName)
		{
			base.SetCurrentAbility(ability , abilityName);
			if( Stat.Blood > 0 )
			{
				UseCurrentAbility();
			}
		}

		private void UseCurrentAbility()
		{
			if( CurrentAbility is IAbility_Strategy strategy )
			{
				strategy.UseAbility(this);
			}
		}
	}
}