using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "ScriptableObjects/Enemy/Enemy")]
public class EnemyBase : ScriptableObject
{
    [Header("Enemy Info")]
    [SerializeField] public int itemDrops;
    [SerializeField] int level;
    [SerializeField] public LootBase lootTable;
}
