using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Actions;

namespace VartraAbyss.Utility
{
	public class ActionQueue : MonoBehaviour
	{
		private Queue<Action> m_currentActionQueue = new Queue<Action>();

		public Queue<Action> CurrentActionQueue => m_currentActionQueue;

		private void FixedUpdate()
		{
			if(m_currentActionQueue.Count == 0)
			{
				return;
			}
			else if(m_currentActionQueue.Count > 0)
			{
				ExecuteAction();
			}
		}

		public void AddToQueue(Action action)
		{
			m_currentActionQueue.Enqueue(action);
		}

		public void RemoveFromQueue(Action action)
		{
			m_currentActionQueue.TryDequeue(out action);
		}

		public void ClearQueue()
		{
			m_currentActionQueue.Clear();
		}

		public void ExecuteAction()
		{
			m_currentActionQueue.Dequeue();
		}
	}
}