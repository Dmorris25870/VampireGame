using UnityEngine;

namespace VartraAbyss.Utility
{
	public static class GameObjectExtension
	{
		public static T GetOrAdd<T>(this GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if( !component )
				component = gameObject.AddComponent<T>();

			return component;
		}
	}
}
