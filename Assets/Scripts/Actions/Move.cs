using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Entity;
using VartraAbyss.Utility;


namespace VartraAbyss.Actions
{
    public class Move : Action
    {	
		public Move()
		{
			m_actionType = ActionTypes.Move;
		}

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
				else if (self.IsAttacking && self.Agent.remainingDistance <= self.AbilityDistance)
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