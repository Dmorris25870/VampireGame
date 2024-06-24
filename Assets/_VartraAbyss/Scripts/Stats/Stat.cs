using UnityEngine;

namespace VartraAbyss.Stats
{
	[System.Serializable]
	public class Stat
	{
		public StatScriptableObject playerStats;

		[field: SerializeField] public int Health { get; private set; }
		[field: SerializeField] public int MaximumHealth { get; private set; }
		[field: SerializeField] public int Blood { get; private set; }
		[field: SerializeField] public int MaximumBlood { get; private set; }
		[field: SerializeField] public float MoveSpeed { get; private set; }
		[field: SerializeField] public float MaximumMoveSpeed { get; private set; }

		public void InitializeStats()
		{
			Health = playerStats.health;
			MaximumHealth = playerStats.maximumHealth;
			Blood = playerStats.blood;
			MaximumBlood = playerStats.maximumBlood;
			MoveSpeed = playerStats.moveSpeed;
			MaximumMoveSpeed = playerStats.maximumMoveSpeed;
		}

		public void SetMaximumHealth(int amount)
		{
			MaximumHealth = amount;
		}

		public void SetHealth(int amount)
		{
			Health = amount;
		}

		public void SetMaximumBlood(int amount)
		{
			MaximumBlood = amount;
		}

		public void SetBlood(int amount)
		{
			Blood = amount;
		}

		public void SetMaximumMoveSpeed(int amount)
		{
			MaximumMoveSpeed = amount;
		}

		public void SetMoveSpeed(float amount)
		{
			MoveSpeed = amount;
		}

		public void ModifyHealth(int amount)
		{
			Health += amount;

			if( Health > MaximumHealth )
			{
				Health = MaximumHealth;
			}
		}

		public void ModifyBlood(int amount)
		{
			Blood += amount;

			if( Blood > MaximumBlood )
			{
				Blood = MaximumBlood;
			}
		}

		public void ModifyMoveSpeed(float amount)
		{
			MoveSpeed += amount;

			if( MoveSpeed > MaximumMoveSpeed )
			{
				MoveSpeed = MaximumMoveSpeed;
			}
		}
	}
}