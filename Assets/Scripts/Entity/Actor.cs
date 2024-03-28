using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartaAbyss.Entity
{
	public class Actor : MonoBehaviour
	{
		[SerializeField] private float m_health;
		[SerializeField] private float m_bloodPower;
		[SerializeField] private float m_minimumMoveSpeed;
		[SerializeField] private float m_maximumMoveSpeed;

		public float Health { get { return m_health; } set { m_health = value; } }
		public float BloodPower { get { return m_bloodPower; } set { m_bloodPower = value; } }
		public float MinimumMoveSpeed { get { return m_minimumMoveSpeed; } set { m_minimumMoveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
	}
}

