using UnityEngine;
using VartraAbyss.Actions;
using VartraAbyss.Abilities;
using UnityEngine.AI;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace VartraAbyss.Entity
{
	public abstract class Actor : SerializedMonoBehaviour
	{
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[ProgressBar(0 , 100 , ColorGetter = "GetHealthBarColor")]
		[SerializeField] protected int m_health;
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[SerializeField] protected int m_maximumHealth;
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[ProgressBar(0 , 10 , 0.7f , 0 , 0.7f , Segmented = true)]
		[SerializeField] protected int m_blood;
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[SerializeField] protected int m_maximumBlood;
		[TabGroup("Actor","Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[Range(1,10)]
		[SerializeField] protected float m_moveSpeed;
		[TabGroup("Actor" , "Stats" , SdfIconType.GraphUp , TextColor = "blue")]
		[SerializeField] protected float m_maximumMoveSpeed;

		[TabGroup("Actor" , "Actions" , SdfIconType.Activity , TextColor = "white")]
		[SerializeField] protected Action.ActionTypes m_currentAction;
		[TabGroup("Actor" , "Actions" , SdfIconType.Activity , TextColor = "white")]
		[DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.OneLine)]
		[SerializeField] protected Dictionary<Action.ActionTypes, Action> m_listOfActions = new Dictionary<Action.ActionTypes, Action>();

		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] protected Ability m_currentAbility;
		[TabGroup("Actor" , "Abilities" , SdfIconType.Magic , TextColor = "purple")]
		[SerializeField] protected Dictionary<Ability.AbilityTypes, Ability> m_listOfAbilities = new Dictionary<Ability.AbilityTypes, Ability>();

		[TabGroup("Actor" , "Items" , SdfIconType.Grid , TextColor = "cyan")]
		[SerializeField] protected ItemBase m_currentItem;

		[TabGroup("Actor" , "Components" , SdfIconType.ExclamationTriangle , TextColor = "red")]
		[Required]
		[SerializeField] protected NavMeshAgent m_agent;
		[TabGroup("Actor" , "Components" , SdfIconType.ExclamationTriangle , TextColor = "red")]
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
		public Dictionary<Action.ActionTypes, Action> ListOfActions { get { return m_listOfActions; } set { m_listOfActions = value; } }
		public Actor Target { get { return m_target; } set { m_target = value; } }

		public virtual void SpawnActor(){ }
		public virtual void SpawnActor(Actor actorToSpawn){ }
		public virtual void SpawnActor(Actor actorToSpawn, Vector3 spawnLocation){ }
		public virtual void Die(){ }
		public virtual void Die(Actor actorToDie){ }
		public virtual void DespawnActor(){ }
		public virtual void DespawnActor(Actor actorToDespawn){ }
		public virtual void DespawnActor(Actor actorToDespawn, float time){ }

		private Color GetHealthBarColor(float value)
		{
			return Color.Lerp(Color.red , Color.green , Mathf.Pow(value / 100f , 2));
		}
	}
}

