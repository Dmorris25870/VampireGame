using UnityEngine;
using VartraAbyss.Actions;
using VartraAbyss.Abilities;
using UnityEngine.AI;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using VartraAbyss.Stats;

namespace VartraAbyss.Entity
{
	public abstract class Actor : SerializedMonoBehaviour
	{
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[SerializeField] protected Stat stat;
		
		[TabGroup("Actor" , "Actions" , SdfIconType.Activity , TextColor = "white")]
		[SerializeField] protected Action.ActionTypes m_currentAction;

		[Space(20)]

		[TabGroup("Actor" , "Actions" , SdfIconType.Activity , TextColor = "white")]
		[DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine)]
		[SerializeField] protected Dictionary<Action.ActionTypes, Action> listOfActions = new();

		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] protected Ability currentAbility;

		[Space(20)]

		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] protected Dictionary<Ability.AbilityNames, Ability> listOfAbilities = new();

		[TabGroup("Actor" , "Items" , SdfIconType.Grid , TextColor = "cyan")]
		[SerializeField] protected ItemBase currentItem;

		[Space(20)]

		[TabGroup("Actor" , "Components" , SdfIconType.ExclamationTriangle , TextColor = "red")]
		[Required]
		[SerializeField] protected NavMeshAgent m_agent;

		[Space(20)]

		[TabGroup("Actor" , "Components" , SdfIconType.ExclamationTriangle , TextColor = "red")]
		[SerializeField] protected LayerMask ignorePlayerLayer;

		protected bool m_isMoving;
		protected bool m_isAttacking;
		protected Vector3 m_clickPoint;
		protected Actor m_target;

		public bool IsMoving { get => m_isMoving; set { m_isMoving = value; } }
		public bool IsAttacking { get => m_isAttacking; set { m_isAttacking = value; } }
		public Stat Stat => stat;

		public Ability CurrentAbility => currentAbility;
		public ItemBase CurrentItem => currentItem;
		public NavMeshAgent Agent { get => m_agent; set { m_agent = value; } }
		public LayerMask IgnorePlayerLayer => ignorePlayerLayer;
		public Vector3 ClickPoint { get => m_clickPoint; set { m_clickPoint = value; } }
		public Action.ActionTypes CurrentAction { get => m_currentAction; set { m_currentAction = value; } }
		public Dictionary<Action.ActionTypes, Action> ListOfActions { get => listOfActions; set { listOfActions = value; } }
		public Actor Target { get => m_target; set { m_target = value; } }

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

