using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Entity;

namespace VartaAbyss.Actions
{
	public abstract class Action : MonoBehaviour
	{
		public enum ActionTypes
		{
			Unset,
			Move,
			Attack,
			UseItem,
			Interact,
			CastAbility,
			Cancel
		}

		public virtual void PerformAction(){ }
		public virtual void PerformAttack(Actor target) { }
		public virtual void PerformAttack(Actor self, Actor target) { }
		public virtual void AddToQueue(){ }
	}
}