using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VartraAbyss.Entity;
using VartraAbyss.Inventory;

public class EventManager : SingletonManager<EventManager>
{
	#region Game State Events
	public delegate void GameStateEvent();
	public static GameStateEvent OnGameStarted;
	public static GameStateEvent OnGamePaused;
	public static GameStateEvent OnGameUnpaused;
	public static GameStateEvent OnGameDataSaved;
	public static GameStateEvent OnGameDataLoaded;
	public static GameStateEvent OnGameQuit;
	#endregion

	#region Ability Events
	public delegate void AbilityEvent(Actor self);
    public static AbilityEvent OnActivatedSlot1Ability;
    public static AbilityEvent OnActivatedSlot2Ability;
    public static AbilityEvent OnActivatedSlot3Ability;
	public static AbilityEvent OnActivatedSlot4Ability;
	public static AbilityEvent OnActivatedSlot5Ability;
	public static AbilityEvent OnActivatedSlot6Ability;
	#endregion

	#region Inventory Events
	public delegate void ItemDragEvent(ItemDragLITE itemToDrag);
	public static ItemDragEvent OnItemGiving;
	public static ItemDragEvent OnItemDropping;
	public static ItemDragEvent OnItemDrag;
    public static ItemDragEvent OnItemTransferTo;
    public static ItemDragEvent OnItemTransferFrom;
    public static ItemDragEvent OnSortingSlots;

	public delegate void ItemScriptEvent(ItemScriptLITE item);
	public static ItemScriptEvent OnItemEquip;
    public static ItemScriptEvent OnGiveItem;

    public delegate void InventoryItemEvent();
    public static InventoryItemEvent OnInventoryItemFits;
    public static InventoryItemEvent OnReturnItemToOriginalPosition;
	#endregion

	#region Player Input Events
	public delegate void QAbilityEvent();
    public static QAbilityEvent OnQAbility;

    public delegate void WAbilityEvent();
    public static WAbilityEvent OnWAbility;
	#endregion

	#region Levelling Events
	public delegate void ExperienceEvent(int xpAmount);
	public static ExperienceEvent OnGainXPEvent;

	public delegate void LevellingEvent(Actor self);
	public static LevellingEvent OnLevelUpEvent;
	public static LevellingEvent OnRefreshStatsEvent;
	#endregion

	public delegate void SkillsMenuEvent();
    public static SkillsMenuEvent OnSkillsMenu;
    public static SkillsMenuEvent OnSkillsMenuClose;

    public delegate void CanAbsorbAbilityEvent();
    public static CanAbsorbAbilityEvent OnCanAbsorbAbility;
    public static CanAbsorbAbilityEvent OnCannotAbsorbAbility;
}
