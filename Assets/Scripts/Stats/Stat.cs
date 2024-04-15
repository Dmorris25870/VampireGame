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
		[SerializeField] protected int m_health;
		[SerializeField] protected int m_maximumHealth;
		[ProgressBar(0 , 10 , 0.7f , 0 , 0.7f , Segmented = true)]
		[SerializeField] protected int m_blood;
		[SerializeField] protected int m_maximumBlood;
		[Range(1 , 10)]
		[SerializeField] protected float m_moveSpeed;
		[SerializeField] protected float m_maximumMoveSpeed;

		public int Health { get { return m_health; } set { m_health = value; } }
		public int MaximumHealth { get { return m_maximumHealth; } set { m_maximumHealth = value; } }
		public int Blood { get { return m_blood; } set { m_blood = value; } }
		public int MaximumBlood { get { return m_maximumBlood; } set { m_maximumBlood = value; } }
		public float MoveSpeed { get { return m_moveSpeed; } set { m_moveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }

		private Color GetHealthBarColor(float value)
		{
			return Color.Lerp(Color.red , Color.green , Mathf.Pow(value / 100f , 2));
		}
	}
}