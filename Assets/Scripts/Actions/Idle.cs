using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace VartraAbyss.Actions
{
	public class Idle : Action
	{
		public Idle()
		{
			m_actionType = ActionTypes.Idle;
		}
		public override void PerformAction()
		{
			return;
		}
	}
}