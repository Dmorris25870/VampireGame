using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTable", menuName = "ScriptableObjects/LootTable/Table")]
public class LootBase : ScriptableObject
{
    public ItemBase[] items;
}
