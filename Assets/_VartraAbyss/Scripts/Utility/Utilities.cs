using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VartraAbyss.Utility
{
	public class Utilities : MonoBehaviour
	{
		public static float GetDistanceBetweenTwoActors(GameObject actor1 , GameObject actor2)
		{
			float distance = Vector3.Distance(actor1.transform.position , actor2.transform.position);
			return distance;
		}

		public static bool IsPointerOverUIElement()
		{
			PointerEventData eventData = new PointerEventData(EventSystem.current);
			eventData.position = Input.mousePosition;
			List<RaycastResult> results = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData , results);
			return results.Count > 0;
		}
	}
}