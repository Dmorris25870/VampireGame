using UnityEngine;
using VartraAbyss.Utility;

namespace VartraAbyss.Entity
{
	public class RotatePlayerToMouse : MonoBehaviour
	{
		private void Update()
		{
			if( Utilities.IsPointerOverUIElement() )
			{
				return;
			}

			RotateTowardsMousePosition();
		}

		public void RotateTowardsMousePosition()
		{
			Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

			if( Physics.Raycast(mousePosition , out RaycastHit hit) )
			{
				Vector3 mouseWorldPosition = hit.point;
				Vector3 direction = mouseWorldPosition - transform.GetComponentInChildren<Spawner>().transform.position.normalized;
				direction.y = 0;

				Quaternion targetRotation = Quaternion.LookRotation(direction);
				transform.rotation = targetRotation;
			}
		}
	}
}
