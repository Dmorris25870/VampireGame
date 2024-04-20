using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Stats
{
	public class LevellingSystem : MonoBehaviour
	{
		[SerializeField] private int m_currentLevel;
		[SerializeField] private int m_currentXp;
		[SerializeField] private int m_currentXPThreshold;
		[SerializeField] private float m_xpThresholdMultiplier;

		public int CurrentLevel { get { return m_currentLevel; } }
		public int CurrentXP { get { return m_currentXp; } }
		public int CurrentXPThreshold { get { return m_currentXPThreshold; } }
		public float XPThresholdMultiplier { get { return m_xpThresholdMultiplier; } }

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
			m_currentXp += xpGained;

			if( m_currentXp >= m_currentXPThreshold )
			{
				LevelUp();
			}

		}

		private void LevelUp()
		{
			int tempCurrentThreshold;

			m_currentLevel++;
			m_currentXp -= m_currentXPThreshold;
			tempCurrentThreshold = (int)( (float)m_currentXPThreshold * (float)m_xpThresholdMultiplier );
			m_currentXPThreshold = tempCurrentThreshold;

			if( m_currentXp >= m_currentXPThreshold )
			{
				LevelUp();
			}
		}
	}
}