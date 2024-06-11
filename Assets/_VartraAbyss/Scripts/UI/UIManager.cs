using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject skillsMenuObject;
    public GameObject absorbAbiltyText;

	private void Start()
	{
        skillsMenuObject.SetActive(false);
        absorbAbiltyText.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.OnSkillsMenu += OpenSkillsMenu;
        EventManager.OnSkillsMenuClose += CloseSkillsMenu;
        EventManager.OnCanAbsorbAbility += CanAbsorbAbilty;
        EventManager.OnCannotAbsorbAbility += CannotAbsorbAbilty;
    }

    private void OnDisable()
    {
        EventManager.OnSkillsMenu -= OpenSkillsMenu;
        EventManager.OnSkillsMenuClose -= CloseSkillsMenu;
        EventManager.OnCanAbsorbAbility -= CanAbsorbAbilty;
        EventManager.OnCannotAbsorbAbility -= CannotAbsorbAbilty;
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

    private void CanAbsorbAbilty()
    {
        absorbAbiltyText.SetActive(true);
    }

    private void CannotAbsorbAbilty()
    {
        absorbAbiltyText.SetActive(false);
    }
}
