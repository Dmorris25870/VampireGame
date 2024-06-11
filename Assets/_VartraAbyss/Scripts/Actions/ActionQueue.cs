using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Actions;

namespace VartraAbyss.Utility
{
	public class ActionQueue : MonoBehaviour
	{
		public Queue<Action> currentActionQueue = new();

		public void AddToQueue(Action action)
		{
			currentActionQueue.Enqueue(action);
		}

		public Action RemoveFromQueue()
		{
			return currentActionQueue.Dequeue();
		}

		public int GetActionQueueCount()
		{
			return currentActionQueue.Count;
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