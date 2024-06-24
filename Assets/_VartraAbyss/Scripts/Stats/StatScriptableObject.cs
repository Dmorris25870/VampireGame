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

		public int health;
		public int maximumHealth;
		public int blood;
		public int maximumBlood;
		public float moveSpeed;
		public float maximumMoveSpeed;

		public int currentStatPointPool;
	}
}