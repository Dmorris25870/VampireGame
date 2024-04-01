using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Items;
using VartaAbyss.Abilities;

namespace VartaAbyss.Entity
{
	public class Actor : MonoBehaviour
	{
		[SerializeField] private int m_health;
		[SerializeField] private float m_minimumMoveSpeed;
		[SerializeField] private float m_maximumMoveSpeed;
		[SerializeField] private Ability m_currentAbility;

		public int Health { get { return m_health; } set { m_health = value; } }
		public float MinimumMoveSpeed { get { return m_minimumMoveSpeed; } set { m_minimumMoveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
		public Ability CurrentAbility { get { return m_currentAbility; } }
	}
}

