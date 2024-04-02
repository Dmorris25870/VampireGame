using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Abilities;
using VartraAbyss.Entity;
using VartraAbyss.Items;

namespace VartraAbyss.Actions
{
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

		public virtual DamageType GetDamageType(Ability abilityToCheck){ return abilityToCheck.DamageType; }
		public virtual int GetDamageAmount(Ability damageAmount){ return damageAmount.DamageAmount; }
		public virtual float GetCoolDownTimeInSeconds(Ability coolDownTimeInSeconds){ return coolDownTimeInSeconds.CoolDownTimeInSeconds; }
		public virtual void PerformAction(){ }
		public virtual void PerformAction(Actor target) { }
		public virtual void PerformAction(Actor self, Actor target) { }
		public virtual void PerformAction(Actor self, Actor target, float radius){ }
		public virtual void AddToQueue(){ }
	}
}