using UnityEngine;

namespace VartraAbyss.Stats
{
	[System.Serializable]
	public class Stat
	{
		public StatScriptableObject playerStats;

		[field: SerializeField] public float Health { get; private set; }
		[field: SerializeField] public float MaximumHealth { get; private set; }
		[field: SerializeField] public float Blood { get; private set; }
		[field: SerializeField] public float MaximumBlood { get; private set; }
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

		public void SetMaximumHealth(float amount)
		{
			MaximumHealth = amount;
			EventManager.OnHealthChanged?.Invoke();
		}

		public void SetHealth(float amount)
		{
			Health = amount;
			EventManager.OnHealthChanged?.Invoke();
		}

		public void SetMaximumBlood(float amount)
		{
			MaximumBlood = amount;
			EventManager.OnBloodChanged?.Invoke();
		}

		public void SetBlood(float amount)
		{
			Blood = amount;
			EventManager.OnBloodChanged?.Invoke();
		}

		public void SetMaximumMoveSpeed(float amount)
		{
			MaximumMoveSpeed = amount;
		}

		public void SetMoveSpeed(float amount)
		{
			MoveSpeed = amount;
		}

		public void ModifyHealth(float amount)
		{
			Health += amount;

			if( Health > MaximumHealth )
			{
				Health = MaximumHealth;
			}

			EventManager.OnHealthChanged?.Invoke();
		}

		public void ModifyBlood(float amount)
		{
			Blood += amount;

			if( Blood > MaximumBlood )
			{
				Blood = MaximumBlood;
			}

			EventManager.OnBloodChanged?.Invoke();
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