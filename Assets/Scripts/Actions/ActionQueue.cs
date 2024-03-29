using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartaAbyss.Actions;

namespace VartaAbyss.Utility
{
	public class ActionQueue : MonoBehaviour
	{
		private Queue<Action> m_currentActionQueue = new Queue<Action>();
	}
}