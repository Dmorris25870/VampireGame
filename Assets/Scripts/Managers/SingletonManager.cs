using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager : MonoBehaviour
{
    private SingletonManager m_instance;

    public SingletonManager Instance { get; private set; }

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
