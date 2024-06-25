using UnityEngine;

namespace VartraAbyss.Entity
{
	public class RotatePlayerToMouse : MonoBehaviour
	{
		private void Update()
		{
			RotateTowardsMousePosition();
		}

		public void RotateTowardsMousePosition()
		{
			Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

			if( Physics.Raycast(mousePosition , out RaycastHit hit) )
			{
				Vector3 mouseWorldPosition = hit.point;
				Vector3 direction = mouseWorldPosition - transform.GetComponentInChildren<Spawner>().transform.position;
				direction.y = 0;

				Quaternion targetRotation = Quaternion.LookRotation(direction);
				transform.rotation = targetRotation;
			}
		}
	}
}
