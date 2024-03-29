using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartaAbyss.Entity.Enemy
{
	public class EnemyBehaviour : Actor
	{
		private List<ItemBase> items = new List<ItemBase>();
		[SerializeField] EnemyBase enemyBase;
		[SerializeField] GameObject itemObject;
		[SerializeField] GameObject goldObject;
		[SerializeField] float baseGold;
		private void DropItems()
		{
			for ( int i = 0; i < enemyBase.lootTable.items.Length; i++ )
			{
				for ( int j = 0; j < enemyBase.lootTable.items[i].itemWeight; j++ )
				{
					if ( enemyBase.lootTable.items[i] != null )
					{
						items.Add(enemyBase.lootTable.items[i]);
					}
					else Debug.Log("this dude has no items chief");
				}
			}
			Debug.Log(items.Count);
			for ( int i = 0; i < enemyBase.itemDrops; i++ )
			{
				GameObject instantiatedItem = Instantiate(itemObject);
				instantiatedItem.GetComponent<ItemBehaviour>().itemBase = items[Random.Range(0, items.Count)];
				instantiatedItem.GetComponent<ItemBehaviour>().SpawnItem();
			}
			
			GameObject instantiatedGold = Instantiate(goldObject);
			instantiatedGold.GetComponent<GoldBase>().goldValue = baseGold * Random.Range(0.8f,1.2f);
			instantiatedGold.GetComponent<GoldBase>().goldText.text = baseGold + " Gold";
		}

		private void Die()
		{
			DropItems();
		}

		public void OnEnable()
		{
			Die(); //MOVE THIS, DO NOT FORGET, MOVE THIS FUCKER
		}
	}
}