using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private GameObject m_creditsScreen;

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}

	public void LoadSceneAdditive(string sceneName)
	{
		SceneManager.LoadScene(sceneName , LoadSceneMode.Additive);
	}
	public void QuitGame()
	{
		Application.Quit();
	}

	public void ShowCreditsMenu()
	{
		m_creditsScreen.SetActive(true);
	}

	public void HideCreditsMenu()
	{
		m_creditsScreen.SetActive(false);
	}
}
