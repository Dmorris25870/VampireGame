using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Entity;


namespace VartraAbyss.Actions
{
    public class Move : Action
    {	
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
				//else if(self.Agent.remainingDistance <= self.AbilityDistance)
				//{
				//	self.IsMoving = false;
				//	self.IsNotWithinRangeAndAttacking = false;
				//	self.CurrentAction = ActionTypes.CastAbility;
				//}
			}
		}
	}
}