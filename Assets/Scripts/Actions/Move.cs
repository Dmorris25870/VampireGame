using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Entity;


namespace VartaAbyss.Actions
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
			}
		}
	}
}