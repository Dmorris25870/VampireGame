using UnityEngine;

namespace VartraAbyss.UI
{
	public class SpriteToCamera : MonoBehaviour
	{
		public Vector3 lockedRotation = new Vector3(0 , -35 , 0);

		void LateUpdate()
		{
			// Lock the rotation to the specified values
			transform.rotation = Quaternion.Euler(lockedRotation);
		}
	}
}
