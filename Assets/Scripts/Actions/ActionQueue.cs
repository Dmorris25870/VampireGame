using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Actions;

namespace VartraAbyss.Utility
{
	public class ActionQueue : MonoBehaviour
	{
		private Queue<Action> currentActionQueue = new Queue<Action>();

		public Queue<Action> CurrentActionQueue => currentActionQueue;

		private void FixedUpdate()
		{
			if(currentActionQueue.Count == 0)
			{
				return;
			}
			else if(currentActionQueue.Count > 0)
			{
				ExecuteAction();
			}
		}

		public void AddToQueue(Action action)
		{
			currentActionQueue.Enqueue(action);
		}

		public void RemoveFromQueue(Action action)
		{
			currentActionQueue.TryDequeue(out action);
		}

		public void ClearQueue()
		{
			currentActionQueue.Clear();
		}

		public void ExecuteAction()
		{
			currentActionQueue.Dequeue();
		}
	}
}