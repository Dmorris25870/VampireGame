using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Items;

namespace VartaAbyss.Entity
{
	public class Actor : MonoBehaviour
	{
		[SerializeField] private int m_health;
		[SerializeField] private int m_bloodPower;
		[SerializeField] private float m_minimumMoveSpeed;
		[SerializeField] private float m_maximumMoveSpeed;
		[SerializeField] private Weapon m_currentWeapon;

		public int Health { get { return m_health; } set { m_health = value; } }
		public int BloodPower { get { return m_bloodPower; } set { m_bloodPower = value; } }
		public float MinimumMoveSpeed { get { return m_minimumMoveSpeed; } set { m_minimumMoveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
		public Weapon CurrentWeapon { get { return m_currentWeapon; } }
	}
}

