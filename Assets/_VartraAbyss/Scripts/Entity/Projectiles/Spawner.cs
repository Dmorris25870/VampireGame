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
	}
}