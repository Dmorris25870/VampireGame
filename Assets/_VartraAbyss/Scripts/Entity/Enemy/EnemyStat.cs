using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy/Enemy")]
public class EnemyStat : ScriptableObject
{
	[Header("Enemy Info")]
    [SerializeField] public int itemDrops;
    //[SerializeField] private int level; unsure if this will be needed we will see
	[SerializeField] public int enemyHealth;
	[SerializeField] public LootBase lootTable;
	[SerializeField] public float aggroRange;
}
