using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	[SerializeField] private GameObject m_creditsScreen;
	public GameObject titleCard;
	[SerializeField] private GameObject m_loadingScreen;
	[SerializeField] private Image m_loadingBar;
	[SerializeField] private GameObject m_playButton;
	[SerializeField] private float m_loadingTime;

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
		titleCard.SetActive(false);
	}

	public void HideCreditsMenu()
	{
		m_creditsScreen.SetActive(false);
		titleCard.SetActive(true);
	}

	public void ShowLoadingScreen()
	{
		m_loadingScreen.SetActive(true);
		HidePlayButton();
		titleCard.SetActive(false);
		m_loadingBar.fillAmount = 0;
		StartCoroutine(LoadingBarCoroutine());
	}

	public void HideLoadingScreen()
	{
		m_loadingScreen.SetActive(false);
	}

	public void ShowPlayButton()
	{
		m_playButton.SetActive(true);
	}

	public void HidePlayButton()
	{
		m_playButton.SetActive(false);
	}

	private IEnumerator LoadingBarCoroutine()
	{
		m_loadingBar.fillAmount = 0;

		while(m_loadingBar.fillAmount < 1)
		{
			m_loadingBar.fillAmount += 1.0f / m_loadingTime * Time.deltaTime;
			yield return null;
		}

		ShowPlayButton();
	}
}
