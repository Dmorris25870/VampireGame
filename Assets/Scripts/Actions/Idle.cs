using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VartraAbyss.Actions
{
	public class Idle : Action
	{
		public Idle()
		{
			actionType = ActionTypes.Idle;
		}

		/// <summary>
		/// Performs the Idle Action, it does nothing.
		/// </summary>
		public override void PerformAction()
		{
			return;
		}
	}
}