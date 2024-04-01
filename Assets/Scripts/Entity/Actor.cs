using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Items;
using VartaAbyss.Actions;
using VartaAbyss.Abilities;
using UnityEngine.AI;
using AYellowpaper.SerializedCollections;

namespace VartaAbyss.Entity
{
	public abstract class Actor : MonoBehaviour
	{
		[SerializeField] private int m_health;
		[SerializeField] private float m_minimumMoveSpeed;
		[SerializeField] private float m_maximumMoveSpeed;
		[SerializeField] private float m_coolDownTimer;
		[SerializeField] private Action.ActionTypes m_currentAction;
		[SerializeField] private Ability m_currentAbility;
		[SerializeField] private NavMeshAgent m_agent;
		[SerializeField] private LayerMask m_ignorePlayerLayer;
		private float m_currentTimer;
		private bool m_isMoving;
		private Vector3 m_clickPoint;
		private Actor m_target;

		[SerializedDictionary("Action Name", "Action")]
		[SerializeField] SerializedDictionary<Action.ActionTypes, Action> m_listOfActions = new SerializedDictionary<Action.ActionTypes, Action>();

		public bool IsMoving { get { return m_isMoving; } set { m_isMoving = value; } }
		public int Health { get { return m_health; } set { m_health = value; } }
		public float MinimumMoveSpeed { get { return m_minimumMoveSpeed; } set { m_minimumMoveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
		public float CurrentTimer { get { return m_currentTimer; } set { m_currentTimer = value; } }
		public float CoolDownTimer { get { return m_coolDownTimer; } set { m_coolDownTimer = value; } }
		public Ability CurrentAbility { get { return m_currentAbility; } }
		public NavMeshAgent Agent { get { return m_agent; } set { m_agent = value; } }
		public LayerMask IgnorePlayerLayer { get { return m_ignorePlayerLayer; } }
		public Vector3 ClickPoint { get { return m_clickPoint; } set { m_clickPoint = value; } }
		public Action.ActionTypes CurrentAction { get { return m_currentAction; } set { m_currentAction = value; } }
		public SerializedDictionary<Action.ActionTypes, Action> ListOfActions { get { return m_listOfActions; } set { m_listOfActions = value; } }
		public Actor Target { get { return m_target; } set { m_target = value; } }


		public virtual void SpawnActor(){ }
		public virtual void SpawnActor(Actor actorToSpawn){ }
		public virtual void SpawnActor(Actor actorToSpawn, Vector3 spawnLocation){ }
		public virtual void Die(){ }
		public virtual void Die(Actor actorToDie){ }
		public virtual void DespawnActor(){ }
		public virtual void DespawnActor(Actor actorToDespawn){ }
		public virtual void DespawnActor(Actor actorToDespawn, float time){ }
	}
}

