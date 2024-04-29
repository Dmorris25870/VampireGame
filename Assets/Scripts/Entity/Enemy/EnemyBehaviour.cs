using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Stats;
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
		private Stat playerStats;
		public GameObject player;
		public bool isAggroed;
		private ActionQueue actionQueue;

		private void OnEnable()
		{
			enemyHealth = enemyBase.enemyHealth;
			player = GameObject.FindGameObjectWithTag("Player");
			playerStats = player.GetComponent<Stat>();
		}
		private void DropItems()
		{
			for ( int i = 0; i < enemyBase.lootTable.items.Length; i++ )
			{
				for ( int j = 0; j < enemyBase.lootTable.items[i].itemWeight; j++ )
				{
					if ( enemyBase.lootTable.items[i] != null )
					{
						itemsList.Add(enemyBase.lootTable.items[i]);
					}
				}
			}

			for ( int i = 0; i < enemyBase.itemDrops; i++ )
			{
				GameObject instantiatedItem = Instantiate(itemObject);
				instantiatedItem.GetComponent<ItemBehaviour>().itemBase = itemsList[Random.Range(0, itemsList.Count)];
				instantiatedItem.GetComponent<ItemBehaviour>().SpawnItem();
			}
			
			GameObject instantiatedGold = Instantiate(goldObject);
			instantiatedGold.GetComponent<GoldBase>().goldValue = baseGold * Random.Range(0.8f,1.2f);
			instantiatedGold.GetComponent<GoldBase>().goldText.text = baseGold + " Gold";
		}

		public void TakeDamage(int damage)
		{
			enemyHealth -= damage;
			playerStats.Blood += damage;
			playerStats.Blood = Mathf.Clamp(playerStats.Blood,0,playerStats.MaximumBlood);
			if (enemyHealth <= 0)
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
			switch( CurrentAction )
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
					if( IsMoving )
					{
						MoveEnemy();
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
					if( attackTimer == null )
					{
						attackTimer = gameObject.AddComponent<Timer>();
						attackTimer.SetTimer(ListOfActions[ActionTypes.CastAbility].GetCoolDownTimeInSeconds(CurrentAbility));
					}

					if( attackTimer.CurrentTime <= 0 )
					{
						CastAbility();
						attackTimer.ResetTimer();
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

		private void MoveEnemy()
		{
			ListOfActions[ActionTypes.Move].PerformAction(this);
		}

		private void CastAbility()
		{
			ListOfActions[ActionTypes.CastAbility].PerformAction(this , Target);
		}
	}
}