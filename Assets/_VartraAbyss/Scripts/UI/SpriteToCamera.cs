using UnityEngine;

namespace VartraAbyss.UI
{
	public class SpriteToCamera : MonoBehaviour
	{
		public Vector3 lockedRotation = new Vector3(0 , -45 , 0);
		[SerializeField] private GameObject m_sprite;

		void LateUpdate()
		{
			// Lock the rotation to the specified values
			m_sprite.transform.rotation = Quaternion.Euler(lockedRotation);
		}
	}
}
