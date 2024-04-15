using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VartraAbyss.Entity;

public static class EventManager 
{
    public delegate void AbilityEvent(Actor self);
    public static AbilityEvent OnActivatedSlot1Ability;
    public static AbilityEvent OnActivatedSlot2Ability;
    public static AbilityEvent OnActivatedSlot3Ability;
	public static AbilityEvent OnActivatedSlot4Ability;
	public static AbilityEvent OnActivatedSlot5Ability;
	public static AbilityEvent OnActivatedSlot6Ability;

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
