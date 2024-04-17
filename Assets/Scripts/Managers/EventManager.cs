using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using VartraAbyss.Entity;
using VartraAbyss.Inventory;

public static class EventManager 
{
    public delegate void AbilityEvent(Actor self);
    public static AbilityEvent OnActivatedSlot1Ability;
    public static AbilityEvent OnActivatedSlot2Ability;
    public static AbilityEvent OnActivatedSlot3Ability;
	public static AbilityEvent OnActivatedSlot4Ability;
	public static AbilityEvent OnActivatedSlot5Ability;
	public static AbilityEvent OnActivatedSlot6Ability;

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
