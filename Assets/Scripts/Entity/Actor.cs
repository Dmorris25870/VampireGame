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
		[Header("Actor Stats")]
		[SerializeField] protected int m_health;
		[SerializeField] protected int m_maximumHealth;
		[SerializeField] protected int m_blood;
		[SerializeField] protected int m_maximumBlood;
		[SerializeField] protected float m_moveSpeed;
		[SerializeField] protected float m_maximumMoveSpeed;

		[Space(2)]

		[Header("Actor Actions")]
		[SerializeField] protected Action.ActionTypes m_currentAction;
		[SerializedDictionary("Action Name", "Action")]
		[SerializeField] SerializedDictionary<Action.ActionTypes, Action> m_listOfActions = new SerializedDictionary<Action.ActionTypes, Action>();

		[Space(2)]

		[Header("Actor Abilities")]
		[SerializeField] protected Ability m_currentAbility;
		[SerializedDictionary("Ability Name", "Ability")]
		[SerializeField] SerializedDictionary<Ability.AbilityTypes, Ability> m_listOfAbilities = new SerializedDictionary<Ability.AbilityTypes, Ability>();

		[Space(2)]

		[Header("Actor Items")]
		[SerializeField] protected ItemBase m_currentItem;

		[Space(2)]

		[Header("Actor Components")]
		[SerializeField] protected NavMeshAgent m_agent;
		[SerializeField] protected LayerMask m_ignorePlayerLayer;
		protected float m_currentTimer;
		protected bool m_isMoving;
		protected bool m_isAttacking;
		protected Vector3 m_clickPoint;
		protected Actor m_target;

		public bool IsMoving { get { return m_isMoving; } set { m_isMoving = value; } }
		public bool IsAttacking { get { return m_isAttacking; } set { m_isAttacking = value; } }
		public int Health { get { return m_health; } set { m_health = value; } }
		public int MaximumHealth { get { return m_maximumHealth; } set { m_maximumHealth = value; } }
		public int Blood { get { return m_blood; } set { m_blood = value; } }
		public int MaximumBlood { get { return m_maximumBlood; } set { m_maximumBlood = value; } }
		public float MoveSpeed { get { return m_moveSpeed; } set { m_moveSpeed = value; } }
		public float MaximumMoveSpeed { get { return m_maximumMoveSpeed; } set { m_maximumMoveSpeed = value; } }
		public float CurrentTimer { get { return m_currentTimer; } set { m_currentTimer = value; } }
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

