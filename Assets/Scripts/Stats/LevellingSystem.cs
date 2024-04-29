using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Stats
{
	public class LevellingSystem : MonoBehaviour
	{
		[SerializeField] private int currentLevel;
		[SerializeField] private int currentXp;
		[SerializeField] private int currentXPThreshold;
		[SerializeField] private float xpThresholdMultiplier;

		public int CurrentLevel => currentLevel;
		public int CurrentXP => currentXp;
		public int CurrentXPThreshold => currentXPThreshold;
		public float XPThresholdMultiplier => xpThresholdMultiplier;

		private void OnEnable()
		{
			EventManager.OnGainXPEvent += AddXP;
		}

		private void OnDisable()
		{
			EventManager.OnGainXPEvent -= AddXP;
		}

		public void AddXP(int xpGained)
		{
			currentXp += xpGained;

			if( currentXp >= currentXPThreshold )
			{
				LevelUp();
			}

		}

		private void LevelUp()
		{
			int tempCurrentThreshold;

			currentLevel++;
			currentXp -= currentXPThreshold;
			tempCurrentThreshold = (int)( (float)currentXPThreshold * (float)xpThresholdMultiplier );
			currentXPThreshold = tempCurrentThreshold;

			if( currentXp >= currentXPThreshold )
			{
				LevelUp();
			}
		}
	}
}