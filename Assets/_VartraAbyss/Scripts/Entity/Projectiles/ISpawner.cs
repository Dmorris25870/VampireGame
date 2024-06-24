using UnityEngine;

namespace VartraAbyss
{
	public interface ISpawner
	{
		public Vector3 GetTransform();
		public Quaternion GetRotation();
	}
}
