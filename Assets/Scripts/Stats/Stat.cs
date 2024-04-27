using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Stats
{
	[System.Serializable]
	public class Stat
	{
		[ProgressBar(0 , 100 , ColorGetter = "GetHealthBarColor")]
		[SerializeField] protected int health;
		[SerializeField] protected int maximumHealth;
		[ProgressBar(0 , 10 , 0.7f , 0 , 0.7f , Segmented = true)]
		[SerializeField] protected int blood;
		[SerializeField] protected int maximumBlood;
		[Range(1 , 10)]
		[SerializeField] protected float moveSpeed;
		[SerializeField] protected float maximumMoveSpeed;

		public int Health { get => health; set { health = value; } }
		public int MaximumHealth { get => maximumHealth; set { maximumHealth = value; } }
		public int Blood { get => blood; set { blood = value; } }
		public int MaximumBlood { get => maximumBlood; set { maximumBlood = value; } }
		public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; } }
		public float MaximumMoveSpeed { get => maximumMoveSpeed; set { maximumMoveSpeed = value; } }

		private Color GetHealthBarColor(float value)
		{
			return Color.Lerp(Color.red , Color.green , Mathf.Pow(value / 100f , 2));
		}
	}
}