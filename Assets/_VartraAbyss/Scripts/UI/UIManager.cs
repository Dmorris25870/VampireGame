using UnityEngine;

public class UIManager : MonoBehaviour
{
	public GameObject skillsMenuObject;
	public GameObject absorbAbiltyText;
	public GameObject pauseMenuObject;
	public GameObject deathScreenObject;

	private void Start()
	{
		skillsMenuObject.SetActive(false);
		absorbAbiltyText.SetActive(false);
		pauseMenuObject.SetActive(false);
		deathScreenObject.SetActive(false);
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
		pauseMenuObject.SetActive(true);
		Time.timeScale = 0;
	}

	private void ClosePauseMenu()
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

	public void TurnOnGameobject(GameObject gameObject)
	{
		gameObject.SetActive(true);
	}

    public void TurnOffGameobject(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
