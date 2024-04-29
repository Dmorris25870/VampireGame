using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VartraAbyss.Entity;

namespace VartraAbyss.Stats
{
	public class StatSystem : MonoBehaviour
	{
		[SerializeField] private int vitality;
		[SerializeField] private int mind;
		[SerializeField] private int strength;
		[SerializeField] private int dexterity;

		[SerializeField] private float vitalityMultiplier;
		[SerializeField] private float mindMultiplier;
		[SerializeField] private float strengthMultiplier;
		[SerializeField] private float dexterityMultiplier;

		[SerializeField] private int initialStatPointPool;
		[SerializeField] private int currentStatPointPool;
		[SerializeField] private int statPointPoolOnLevelUp;

		public int Vitality => vitality;
		public int Mind => mind;
		public int Strength => strength;
		public int Dexterity => dexterity;

		public void AssignStats()
		{
			currentStatPointPool = initialStatPointPool;

			vitality = Random.Range(5 , currentStatPointPool / 2);
			currentStatPointPool -= vitality;

			mind = Random.Range(5 , currentStatPointPool / 2);
			currentStatPointPool -= mind;

			strength = Random.Range(5 , currentStatPointPool / 2);
			currentStatPointPool -= strength;

			dexterity = currentStatPointPool;
			currentStatPointPool -= dexterity;
			Logger();
		}

		public void CalculateStats(Actor self)
		{
			self.Stat.Health = (int)( (float)vitality * (float)vitalityMultiplier );
			self.Stat.Blood = (int)( (float)mind * (float)mindMultiplier );
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

			//CalculateStats();
		}

		private void Logger()
		{
			Debug.Log($"Player Vitality is: {vitality}. \n Player Mind is: {mind}. \n Player Strength is: {strength}. \n Player Dexterity is: {dexterity}.");
		}
	}
}