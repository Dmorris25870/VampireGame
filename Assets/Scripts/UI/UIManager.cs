using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject SkillsMenuObject;

    public GameObject AbsorbAbiltyText;
    
    void Start()
    {
        SkillsMenuObject.SetActive(false);
        AbsorbAbiltyText.SetActive(false);
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
        SkillsMenuObject.SetActive(true);
        //Time.timeScale = 0f;
    }

    private void CloseSkillsMenu()
    {
        SkillsMenuObject.SetActive(false);
        //Time.timeScale = 1f;
    }

    private void CanAbsorbAbilty()
    {
        AbsorbAbiltyText.SetActive(true);
    }

    private void CannotAbsorbAbilty()
    {
        AbsorbAbiltyText.SetActive(false);
    }
}
