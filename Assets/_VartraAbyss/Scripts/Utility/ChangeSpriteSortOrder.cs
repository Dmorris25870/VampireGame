using UnityEngine;

namespace VartraAbyss
{
	public class ChangeSpriteSortOrder : MonoBehaviour
	{
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

			if(spriteRenderer != null)
			{
				spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.z * 100);
			}
		}
	}
}
