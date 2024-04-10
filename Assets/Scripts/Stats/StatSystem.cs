using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss.Stats
{
	public class StatSystem : MonoBehaviour
	{
		[SerializeField] private int m_vitality;
		[SerializeField] private int m_mind;
		[SerializeField] private int m_strength;
		[SerializeField] private int m_dexterity;

		[SerializeField] private float m_vitalityMultiplier;
		[SerializeField] private float m_mindMultiplier;
		[SerializeField] private float m_strengthMultiplier;
		[SerializeField] private float m_dexterityMultiplier;

		[SerializeField] private int m_initialStatPointPool;
		[SerializeField] private int m_currentStatPointPool;
		[SerializeField] private int m_statPointPoolOnLevelUp;

		public void AssignStats()
		{
			m_currentStatPointPool = m_initialStatPointPool;

			m_vitality = Random.Range(0 , m_currentStatPointPool);
			m_currentStatPointPool -= m_vitality;

			m_mind = Random.Range(0 , m_currentStatPointPool);
			m_currentStatPointPool -= m_mind;

			m_strength = Random.Range(0 , m_currentStatPointPool);
			m_currentStatPointPool -= m_strength;

			m_dexterity = Random.Range(0 , m_currentStatPointPool);
			m_currentStatPointPool -= m_dexterity;
			Logger();
		}

		public void CalculateStats()
		{
			//rhythm = (int)( (float)strength * (float)strengthMultiplier );
			//style = (int)( (float)agility * (float)agilityMultiplier );
			//luck = (int)( (float)intelligence * (float)intelligenceMultiplier );
		}

		public void DistributePhysicalStatsOnLevelUp(int PointsPool)
		{
			//PointsPool = myPointsPool;

			//int tempStrength = PointsPool / myFirstPointDistributer;
			//strength += tempStrength;
			//PointsPool -= tempStrength;
			//int tempAgility = PointsPool / mySecondPointDistributer;
			//agility += tempAgility;
			//PointsPool -= tempAgility;
			//int tempIntelligence = PointsPool;
			//intelligence += tempIntelligence;

			CalculateStats();
		}

		private void Logger()
		{
			Debug.Log($"Player Vitality is: {m_vitality}. \n Player Mind is: {m_mind}. \n Player Strength is: {m_strength}. \n Player Dexterity is: {m_dexterity}.");
		}
	}
}