using UnityEngine;

namespace VartraAbyss.Entity
{
	public class RotatePlayerToMouse : MonoBehaviour
	{
		[field: SerializeField] public bool ToggleRotateToMouse { get; private set; }

		private void LateUpdate()
		{
			if( ToggleRotateToMouse )
			{
				RotateTowardsMousePosition();
			}
		}

		public void ToggleOptionRotateToMouse(bool enabled)
		{
			ToggleRotateToMouse = !enabled;
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
