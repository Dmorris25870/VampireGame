using UnityEngine;

namespace VartraAbyss
{
	public class Spawner : MonoBehaviour, ISpawner
	{
		public Vector3 GetTransform()
		{
			return transform.localPosition;
		}

		public Quaternion GetRotation()
		{
			return transform.localRotation;
		}

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
				Vector3 direction = mouseWorldPosition - transform.position;
				direction.y = 0;

				Quaternion targetRotation = Quaternion.LookRotation(direction);
				transform.rotation = targetRotation;
			}
		}
	}
}