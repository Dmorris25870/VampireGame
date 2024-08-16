using UnityEngine;

namespace VartraAbyss.UI
{
	public class SpriteToCamera : MonoBehaviour
	{
		public Vector3 lockedRotation = new Vector3(0 , -45 , 0);
		[SerializeField] private GameObject m_sprite;
		[SerializeField] private SpriteRenderer spriteRenderer;

		private void Awake()
		{
			if(spriteRenderer == null)
			{
				spriteRenderer = GetComponent<SpriteRenderer>();
			}
		}

		void LateUpdate()
		{
			// Lock the rotation to the specified values
			m_sprite.transform.rotation = Quaternion.Euler(lockedRotation);

			if(spriteRenderer != null)
			{
				spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.z * 100);
			}
		}
	}
}
