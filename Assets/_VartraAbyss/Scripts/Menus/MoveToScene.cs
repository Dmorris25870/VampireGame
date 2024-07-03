using Unity.VisualScripting;
using UnityEngine;

public class MoveToScene : MonoBehaviour
{
	[SerializeField] private SceneLoader m_sceneLoader;

	private void Start()
	{
		m_sceneLoader.GetOrAddComponent<SceneLoader>();
	}

	public void LoadMenu()
	{
		m_sceneLoader.LoadScene("MainMenu");
	}

	public void ExitGame()
	{
		m_sceneLoader.QuitGame();
	}
}
