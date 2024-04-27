using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Utility;

namespace VartraAbyss.Actions
{
	/// <summary>
	/// Move Action that handles the movement of an Actor.
	/// </summary>
    public class Move : Action
    {	
		public Move()
		{
			m_actionType = ActionTypes.Move;
		}

		/// <summary>
		/// Performs the Move Action, passing in an Actor, setting the destination to the point where the user clicked.
		/// Once the Actor has reached the destination, it stops moving and switches the the Idle Action.
		/// If the Actor was attacking and reaches within the Ability/Attack distance, then it will stop moving, reset the path and Cast the Ability / Attack.
		/// </summary>
		/// <param name="self"></param>
		public override void PerformAction(Actor self)
		{
			self.Agent.SetDestination(self.ClickPoint);

			if ( !self.Agent.pathPending )
			{
				if ( self.Agent.remainingDistance <= self.Agent.stoppingDistance )
				{
					if ( !self.Agent.hasPath || self.Agent.velocity.sqrMagnitude == 0f )
					{
						self.IsMoving = false;
						self.CurrentAction = ActionTypes.Idle;
					}
				}
				else if (self.IsAttacking && self.Agent.remainingDistance <= self.CurrentAbility.AbilityDistance)
				{
					self.IsMoving = false;
					self.Agent.ResetPath();
					self.CurrentAction = ActionTypes.CastAbility;
					self.IsAttacking = false;
				}
			}
		}

		public override void AddToQueue()
		{
			
		}
	}
}