using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T>
{
    public static SingletonManager<T> Instance;

	private void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

		DontDestroyOnLoad(gameObject);
	}
}
