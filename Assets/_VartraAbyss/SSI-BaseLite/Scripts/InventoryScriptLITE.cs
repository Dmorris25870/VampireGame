﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace VartraAbyss.Inventory
{
	public class InventoryScriptLITE : MonoBehaviour
	{
		//this manages all of the inventory based interactions (ie equipping guns and picking up items)
		public KeyCode inventoryKey = KeyCode.Tab;
		public KeyCode useKey = KeyCode.E;

		public float rayLength = 2;
		private Transform lookingAt;
		[Tooltip("The layermask used when it comes to raycasting for items.")]
		public LayerMask layerMask;
		private float timer;

		[Tooltip("This is for when the player has more than one inventory grid.")]
		public InventoryGridScriptLITE bag;
		private ItemScriptLITE[] items;
		private bool doesFit = false; //this is used when more than one bag is used

		//this is all the ui stuff
		[Tooltip("Don't change this to True or else the code may break.")]
		public bool inventory = false; //this is the check to see if the player is in the inventory, it's public so that other scripts can access it, don't change this
		public RectTransform inventoryPanel;
		public float canvasMoveSpeed = 1;

		[Range(0.25f, 1)]
		public float uiScale = 0.5f; //the scale of the grids, default = 0.5f
		private float scaleMultiplier; //the scale compared to the default value (ie uiScale of 0.5f will have a multiplier of 1)

		public GameObject itemPrompt;

		private void OnEnable()
		{
			EventManager.OnItemEquip += Equip;
			EventManager.OnInventoryItemFits += DoesFit;
		}

		private void OnDisable()
		{
			EventManager.OnItemEquip -= Equip;
			EventManager.OnInventoryItemFits -= DoesFit;
		}

		private void Start()
		{
			scaleMultiplier = uiScale / 0.5f;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			RectTransform parentRect;
			parentRect = bag.transform.parent.GetComponent<RectTransform>();

			bag.GetComponent<RectTransform>().localScale = new Vector3(uiScale, uiScale, uiScale);
			if ( bag.GetComponent<RectTransform>().rect.height * bag.GetComponent<RectTransform>().localScale.y > parentRect.rect.height )
			{
				parentRect.offsetMin = new Vector2(parentRect.offsetMin.x, 0 - ( ( bag.height * 25 * scaleMultiplier ) - parentRect.rect.height ));
				bag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			}
			else
			{
				parentRect.offsetMin = new Vector2(0, 0);
				bag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
			}
			if ( bag.GetComponent<RectTransform>().rect.width > parentRect.rect.width )
			{
				parentRect.offsetMin = new Vector2(0 - ( ( bag.width * 25 * scaleMultiplier ) - parentRect.rect.width ), parentRect.offsetMin.y);
			}
			parentRect.parent.GetComponent<ScrollRect>().horizontalNormalizedPosition = 0;
		}

		private void Update()
		{
			RaycastHit hit;
			Vector3 fwd = transform.TransformDirection(Vector3.forward);

			if ( Input.GetKeyDown(inventoryKey) )
			{
				inventory = !inventory;
				if ( inventory )
				{
					inventoryPanel.anchorMax = new Vector2(1, 1);
					inventoryPanel.anchorMin = new Vector2(0, 0);
				}
				else
				{
					inventoryPanel.anchorMax = new Vector2(1, 0);
					inventoryPanel.anchorMin = new Vector2(0, -1);
				}
			}

			if ( Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMask) )
			{
				itemPrompt.SetActive(true);
				if ( hit.transform != lookingAt )
				{
					if ( lookingAt != null )
					{
						lookingAt = null;
					}

					lookingAt = hit.transform;
				}
				if ( Input.GetKeyUp(useKey) )
				{
					doesFit = false;
					ItemScriptLITE temp = hit.transform.GetComponent<ItemScriptLITE>();
					if ( bag.freeSpaces >= temp.width * temp.height )
					{
						EventManager.OnGiveItem?.Invoke(temp);
					}
					if ( doesFit == false )
					{
						StartCoroutine("NotEnough");
					}
				}
				if ( Input.GetKey(useKey) )
				{
					timer += Time.deltaTime;
					if ( timer >= 0.4 )
					{
						timer = 0;
					}
				}
				if ( !Input.GetKey(useKey) )
				{
					timer = 0;
				}
			}
			else if ( lookingAt != null )
			{
				itemPrompt.SetActive(false);
				itemPrompt.GetComponent<Text>().text = "E to Take Item";
				itemPrompt.GetComponent<Text>().color = Color.white;
				StopCoroutine("NotEnough");
				lookingAt = null;
			}
		}

		private IEnumerator NotEnough()
		{
			itemPrompt.GetComponent<Text>().text = "Not Enough Space";
			itemPrompt.GetComponent<Text>().color = Color.red;
			yield return new WaitForSeconds(1);
			itemPrompt.GetComponent<Text>().text = "E to Take Item";
			itemPrompt.GetComponent<Text>().color = Color.white;
		}

		private void Equip(ItemScriptLITE item)
		{
		}

		private void GiveItem(ItemScriptLITE item)
		{
			doesFit = false;
			ItemScriptLITE temp = item;
			if ( bag.freeSpaces >= temp.width * temp.height )
			{
				EventManager.OnGiveItem?.Invoke(temp);
			}
			else
			{
				StartCoroutine("NotEnough");
			}
		}

		private void UnloadItem(ItemScriptLITE item)
		{ //used for example, when reloading and there isnt enough space
			doesFit = false;
			ItemScriptLITE temp = item;
			if ( bag.freeSpaces >= temp.width * temp.height )
			{
				EventManager.OnGiveItem?.Invoke(temp);
			}
			if ( doesFit == false )
			{
				item.obj.gameObject.SetActive(true);
				item.obj.transform.position = transform.position;
				item.transform.eulerAngles = new Vector3(0, 0, 0);
				item.obj.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * 2);
				item.obj.transform.SetParent(null);
			}
		}

		private void DoesFit()
		{
			doesFit = true;
		}
	}
}