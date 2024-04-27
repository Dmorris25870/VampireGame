using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Abilities;
using VartraAbyss.Entity;
using VartraAbyss.Items;

namespace VartraAbyss.Actions
{
	/// <summary>
	/// The Base Class for any Action.
	/// </summary>
	public abstract class Action : MonoBehaviour
	{
		public enum ActionTypes
		{
			Unset,
			Idle,
			Move,
			UseItem,
			Interact,
			CastAbility,
			Cancel
		}

		protected ActionTypes m_actionType;

		public ActionTypes ActionType => m_actionType;

		/// <summary>
		/// Returns the Damage Type of an Ability.
		/// </summary>
		/// <param name="abilityToCheck"></param>
		/// <returns></returns>
		public virtual DamageType GetDamageType(Ability abilityToCheck){ return abilityToCheck.DamageType; }

		/// <summary>
		/// Returns the Damage Amount of an Ability.
		/// </summary>
		/// <param name="damageAmount"></param>
		/// <returns></returns>
		public virtual int GetDamageAmount(Ability damageAmount){ return damageAmount.DamageAmount; }

		/// <summary>
		/// Returns the Cooldown Time, in seconds, of an Ability.
		/// </summary>
		/// <param name="coolDownTimeInSeconds"></param>
		/// <returns></returns>
		public virtual float GetCoolDownTimeInSeconds(Ability coolDownTimeInSeconds){ return coolDownTimeInSeconds.CoolDownTimeInSeconds; }

		/// <summary>
		/// Performs the designated Action.
		/// </summary>
		public virtual void PerformAction(){ }

		/// <summary>
		/// Performs the designated Action, passing through an Actor as the target.
		/// </summary>
		/// <param name="target"></param>
		public virtual void PerformAction(Actor target) { }

		/// <summary>
		/// Performs the designated Action, passing through 2 Actors, self and the target.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="target"></param>
		public virtual void PerformAction(Actor self, Actor target) { }

		/// <summary>
		/// Performs the designated Action, passing through 2 Actors, self and the target, and a Float radius.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="target"></param>
		/// <param name="radius"></param>
		public virtual void PerformAction(Actor self, Actor target, float radius){ }

		/// <summary>
		/// Performs the designated Action, passing through an Actor, self, and an ItemBase.
		/// </summary>
		/// <param name="self"></param>
		/// <param name="itemToUse"></param>
		public virtual void PerformAction(Actor self, ItemBase itemToUse){ }

		/// <summary>
		/// Add the Action to the ActionQueue.
		/// </summary>
		public virtual void AddToQueue(){ }
	}
}