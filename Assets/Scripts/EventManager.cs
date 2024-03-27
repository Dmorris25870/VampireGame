using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    public delegate void QAbilityEvent();
    public static QAbilityEvent OnQAbility;

    public delegate void WAbilityEvent();
    public static WAbilityEvent OnWAbility;

    public delegate void SkillsMenuEvent();
    public static SkillsMenuEvent OnSkillsMenu;
    public static SkillsMenuEvent OnSkillsMenuClose;

    public delegate void CanAbsorbAbilityEvent();
    public static CanAbsorbAbilityEvent OnCanAbsorbAbility;
    public static CanAbsorbAbilityEvent OnCannotAbsorbAbility;
}
