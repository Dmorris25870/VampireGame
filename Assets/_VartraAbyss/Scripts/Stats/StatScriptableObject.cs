using UnityEngine;

namespace VartraAbyss.Stats
{
	[CreateAssetMenu(fileName = "NewStat" , menuName = "ScriptableObjects/Stats/Stat")]
	public class StatScriptableObject : ScriptableObject
	{
		public int vitality;
		public int mind;
		public int strength;
		public int dexterity;

		public float health;
		public float maximumHealth;
		public float blood;
		public float maximumBlood;
		public float moveSpeed;
		public float maximumMoveSpeed;

		public int currentStatPointPool;
	}
}