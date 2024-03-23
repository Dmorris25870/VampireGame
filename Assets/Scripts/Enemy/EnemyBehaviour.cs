using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBehaviour : MonoBehaviour
{
    private List<ItemBase> items = new List<ItemBase>();
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] GameObject itemObject;
    private void DropItems()
    {
        for (int i = 0; i < enemyBase.lootTable.items.Length; i++)
        {
            for (int j = 0; j < enemyBase.lootTable.items[i].itemWeight; j++)
            {
                if (enemyBase.lootTable.items[i] != null)
                {
                    items.Add(enemyBase.lootTable.items[i]);
                }
                else Debug.Log("this dude has no items chief");
            }
        }
        Debug.Log(items.Count);
        for (int i = 0; i < enemyBase.itemDrops; i++)
        {
            GameObject instantiateditem = Instantiate(itemObject);
            instantiateditem.GetComponent<ItemBehaviour>().itemBase = items[Random.Range(0, items.Count)];
            instantiateditem.GetComponent<ItemBehaviour>().SpawnItem();
        }
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
