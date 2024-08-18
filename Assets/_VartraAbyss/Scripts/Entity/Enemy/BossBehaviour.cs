using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VartraAbyss.Abilities;
using VartraAbyss.Actions;
using VartraAbyss.Entity.Player;
using VartraAbyss.Utility;
using static VartraAbyss.Actions.Action;

namespace VartraAbyss.Entity.Boss
{
	public class BossBehaviour : Actor
	{
		//[SerializeField] private List<ItemBase> itemsList = new();
		//[SerializeField] private GameObject itemObject;
		[SerializeField] private EnemyStat enemyBase;
		//[SerializeField] private GameObject goldObject;
		//[SerializeField] private float baseGold;
		[SerializeField] public int enemyHealth;
		[SerializeField] private Timer attackTimer;
		[SerializeField] private bool isAbilityEnemy;

		private PlayerBehaviour playerBehaviour;
		public GameObject player;
		public bool isAggroed;
		private float aggroRange;
		public ParticleSystem damageEffect;
		public bool isFightStarted;
		public bool isFelix;
		private int Rng;

		private void Start()
		{
			SetupActions();
			enemyHealth = enemyBase.enemyHealth;
			aggroRange = enemyBase.aggroRange;
			player = GameObject.FindGameObjectWithTag("Player");
			playerBehaviour = player.GetComponent<PlayerBehaviour>();
			SetNavMeshAgent(GetComponent<NavMeshAgent>());
			Stat.MaximumHealth = enemyHealth;
			Stat.Health = enemyHealth;
			//isFightStarted = false;
			if (!isFelix)
            {
				EventManager.OnZeroFight += StartFight;
            }
			else if (isFelix)
            {
				EventManager.OnFelixFight += StartFight;
            }
			//SetCurrentAbility(null , "Bite");
		}

		//private void DropItems()
		//{
		//	for(int i = 0; i < enemyBase.lootTable.items.Length; i++)
		//	{
		//		for(int j = 0; j < enemyBase.lootTable.items[i].itemWeight; j++)
		//		{
		//			if(enemyBase.lootTable.items[i] != null)
		//			{
		//				itemsList.Add(enemyBase.lootTable.items[i]);
		//			}
		//		}
		//	}

		//	for(int i = 0; i < enemyBase.itemDrops; i++)
		//	{
		//		GameObject instantiatedItem = Instantiate(itemObject , gameObject.transform.position , Quaternion.identity);
		//		instantiatedItem.GetComponent<ItemBehaviour>().itemBase = itemsList[Random.Range(0 , itemsList.Count)];
		//		instantiatedItem.GetComponent<ItemBehaviour>().SpawnItem();
		//	}

		//	GameObject instantiatedGold = Instantiate(goldObject , gameObject.transform.position , Quaternion.identity);
		//	instantiatedGold.GetComponent<GoldBase>().goldValue = baseGold * Random.Range(0.8f , 1.2f);
		//	instantiatedGold.GetComponent<GoldBase>().goldText.text = baseGold + " Gold";
		//}

		public void TakeDamage(int amount)
		{
			Debug.Log("took damage" + amount);
			Stat.Health += amount;
			if(amount < 0)
			{
				PlayDamageEffect();
				EventManager.OnBossHealthChanged?.Invoke();
			}
			if(Stat.Health <= 0)
			{
				Die();
			}
		}

		public void PlayDamageEffect()
		{
			Instantiate(damageEffect , transform.position , transform.rotation);
		}

		public override void Die()
		{
			EventManager.OnBossFightClose?.Invoke();
			//DropItems();
			Destroy(this.gameObject);
		}

		private void FixedUpdate()
		{

			if(IsWithinAggroRange(gameObject , player) && isFightStarted)
			{
				if (isFelix)
				{
					Rng = Random.Range(0, 4);
					if (Rng <= 1)
					{
						SetCurrentAbility(null, "FelixWave");
					}
					else
                    {
						SetCurrentAbility(null, "FelixSword");
                    }
				}
				if (!isFelix)
				{
					Rng = Random.Range(0, 4);
					if (Rng <= 1)
					{
						SetCurrentAbility(null, "ZeroWave");
					}
					else
					{
						SetCurrentAbility(null, "ZeroStrike");
					}
				}
				SetTarget(player.transform.position);
				if(IsWithinAbilityRange(gameObject , player))
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

			if(ListOfActions.TryGetValue(CurrentAction , out Action action))
			{
				// 1st param is self, then a Vector, 
				action.Execute(this , Target);
			}
		}

		private void StartFight()
        {
			EventManager.OnBossFight?.Invoke();
			isFightStarted = true;
        }

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
		}
	}
}