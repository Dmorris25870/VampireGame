using UnityEngine;
using VartraAbyss.Utility;

public class MoveToScene : MonoBehaviour
{
	[SerializeField] private GameObject m_sceneLoader;

	private void Start()
	{
		m_sceneLoader.GetOrAdd<SceneLoader>();
	}

	public void LoadMenu()
	{
		m_sceneLoader.GetComponent<SceneLoader>().LoadScene("MainMenu");
	}

	public void ExitGame()
	{
		m_sceneLoader.GetComponent<SceneLoader>().QuitGame();
	}
}
