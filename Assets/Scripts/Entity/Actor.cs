using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Items;
using VartraAbyss.Actions;
using VartraAbyss.Abilities;
using UnityEngine.AI;
using AYellowpaper.SerializedCollections;

namespace VartraAbyss.Entity
{
	public abstract class Actor : MonoBehaviour
	{
		[SerializeField] protected int m_health;
		[SerializeField] protected float m_moveSpeed;
		[SerializeField] protected float m_maximumMoveSpeed;
		[SerializeField] protected float m_coolDownTimer;
		[SerializeField] protected NavMeshAgent m_agent;
		[SerializeField] protected LayerMask m_ignorePlayerLayer;
		[SerializeField] protected Action.ActionTypes m_currentAction;
		[SerializeField] protected Ability m_currentAbility;
		[SerializeField] protected ItemBase m_currentItem;
		[SerializeField] protected float m_abilityDistance = 5.0f;
		protected float m_currentTimer;
		protected bool m_isMoving;
		protected bool m_isNotWithinRangeAndAttacking;
		protected Vector3 m_clickPoint;
		protected Actor m_target;

		[SerializedDictionary("Action Name", "Action")]
		[SerializeField] SerializedDictionary<Action.ActionTypes, Action> m_listOfActions = new SerializedDictionary<Action.ActionTypes, Action>();

		public bool IsMoving { get { return m_isMoving; } set { m_isMoving = value; } }
		public bool IsNotWithinRangeAndAttacking { get { return m_isNotWithinRangeAndAttacking; } set { m_isNotWithinRangeAndAttacking = value; } }
		public int Health { get { return m_health; } set { m_health = value; } }
		public float MoveSpeed { get { return m_moveSpeed; } set { m_moveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
		public float AbilityDistance { get { return m_abilityDistance; } }
		public float CurrentTimer { get { return m_currentTimer; } set { m_currentTimer = value; } }
		public float CoolDownTimer { get { return m_coolDownTimer; } set { m_coolDownTimer = value; } }
		public Ability CurrentAbility { get { return m_currentAbility; } }
		public ItemBase CurrentItem { get { return m_currentItem; } }
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

