using UnityEngine;

public class UIManager : MonoBehaviour
{
	public GameObject skillsMenuObject;
	public GameObject absorbAbiltyText;
	public GameObject pauseMenuObject;
	public GameObject deathScreenObject;
	public GameObject controlsMenuObject;

	private void Start()
	{
		skillsMenuObject.SetActive(false);
		absorbAbiltyText.SetActive(false);
		pauseMenuObject.SetActive(false);
		deathScreenObject.SetActive(false);
		controlsMenuObject.SetActive(false);
	}

	private void OnEnable()
	{
		EventManager.OnSkillsMenu += OpenSkillsMenu;
		EventManager.OnSkillsMenuClose += CloseSkillsMenu;
		EventManager.OnCanAbsorbAbility += CanAbsorbAbilty;
		EventManager.OnCannotAbsorbAbility += CannotAbsorbAbilty;
		EventManager.OnGamePaused += OpenPauseMenu;
		EventManager.OnGameUnpaused += ClosePauseMenu;
		EventManager.OnPlayerDeathEvent += DeathScreen;
	}

	private void OnDisable()
	{
		EventManager.OnSkillsMenu -= OpenSkillsMenu;
		EventManager.OnSkillsMenuClose -= CloseSkillsMenu;
		EventManager.OnCanAbsorbAbility -= CanAbsorbAbilty;
		EventManager.OnCannotAbsorbAbility -= CannotAbsorbAbilty;
		EventManager.OnGamePaused -= OpenPauseMenu;
		EventManager.OnGameUnpaused -= ClosePauseMenu;
		EventManager.OnPlayerDeathEvent -= DeathScreen;
	}

	public void TurnOnObject(GameObject gameObject)
	{
		gameObject.SetActive(true);
	}

	public void TurnOffObject(GameObject gameObject)
	{
		gameObject.SetActive(false); 
	}

	private void OpenSkillsMenu()
	{
		skillsMenuObject.SetActive(true);
		//Time.timeScale = 0f;
	}

	private void CloseSkillsMenu()
	{
		skillsMenuObject.SetActive(false);
		//Time.timeScale = 1f;
	}

	private void OpenPauseMenu()
	{
		Debug.Log("OpenPauseMenu");
		pauseMenuObject.SetActive(true);
		Time.timeScale = 0;
	}

	public void ClosePauseMenu()
	{
		pauseMenuObject.SetActive(false);
		Time.timeScale = 1;
	}

	private void DeathScreen()
	{
		deathScreenObject.SetActive(true);
		Time.timeScale = 0;
	}

	private void CanAbsorbAbilty()
	{
		absorbAbiltyText.SetActive(true);
	}

	private void CannotAbsorbAbilty()
	{
		absorbAbiltyText.SetActive(false);
	}
}
