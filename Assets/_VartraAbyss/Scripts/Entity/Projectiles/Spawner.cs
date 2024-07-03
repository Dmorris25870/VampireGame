using UnityEngine;

namespace VartraAbyss
{
	public class Spawner : MonoBehaviour, ISpawner
	{
		public Transform pivot;
		public float radius;

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
			//RotateTowardsMousePosition();
		}

		public void RotateTowardsMousePosition()
		{
			Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

			if( Physics.Raycast(mousePosition , out RaycastHit hit) )
			{
				Vector3 mouseWorldPosition = hit.point;
				Vector3 direction = mouseWorldPosition - pivot.position;
				direction.y = 0;

				if( direction.magnitude > radius )
				{
					direction = direction.normalized * radius;
				}
				transform.position = pivot.position + direction;

				Vector3 lookDirection = ( transform.position - pivot.position ).normalized;
				transform.rotation = Quaternion.LookRotation(Vector3.forward , lookDirection);
			}
		}
	}
}