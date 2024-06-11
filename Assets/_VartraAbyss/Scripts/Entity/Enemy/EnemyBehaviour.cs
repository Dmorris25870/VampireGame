using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Entity.Enemy
{
	public class EnemyBehaviour : Actor
	{
		[SerializeField] private List<ItemBase> m_itemsList = new();
		[SerializeField] private EnemyBase m_enemyBase;
		[SerializeField] private GameObject m_itemObject;
		[SerializeField] private GameObject m_goldObject;
		[SerializeField] private float m_baseGold;

		private void DropItems()
		{
			for( int i = 0; i < m_enemyBase.lootTable.items.Length; i++ )
			{
				for( int j = 0; j < m_enemyBase.lootTable.items[i].itemWeight; j++ )
				{
					if( m_enemyBase.lootTable.items[i] != null )
					{
						m_itemsList.Add(m_enemyBase.lootTable.items[i]);
					}
				}
			}

			for( int i = 0; i < m_enemyBase.itemDrops; i++ )
			{
				GameObject instantiatedItem = Instantiate(m_itemObject);
				instantiatedItem.GetComponent<ItemBehaviour>().itemBase = m_itemsList[Random.Range(0 , m_itemsList.Count)];
				instantiatedItem.GetComponent<ItemBehaviour>().SpawnItem();
			}

			GameObject instantiatedGold = Instantiate(m_goldObject);
			instantiatedGold.GetComponent<GoldBase>().goldValue = m_baseGold * Random.Range(0.8f , 1.2f);
			instantiatedGold.GetComponent<GoldBase>().goldText.text = m_baseGold + " Gold";
		}

		public override void Die(params object[] deathData)
		{
			DropItems();
		}
	}
}