using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace VartraAbyss.Inventory
{
	public class ItemDragLITE : MonoBehaviour
	{
		public GameObject panel;
		public RectTransform rect;
		public Vector2 originalPos;
		public Vector2 originalScale;
		public Vector3 originalRot;
		private Transform oldParent;
		public ItemScriptLITE obj;
		public GameObject equipButton;
		public GameObject dropButton;

		private void OnEnable()
		{
			EventManager.OnReturnItemToOriginalPosition += ReturnToNormal;
		}

		private void OnDisable()
		{
			EventManager.OnReturnItemToOriginalPosition -= ReturnToNormal;
		}

		private void Awake()
		{
			rect = GetComponent<RectTransform>();
		}

		private void Start()
		{
			panel = GameObject.FindGameObjectWithTag("ItemPanel");
			oldParent = transform.parent;
			originalPos = rect.anchoredPosition;
			originalScale = rect.localScale;
			originalRot = transform.Find("image").localEulerAngles;
			equipButton = panel.transform.Find("Equip").gameObject;
			dropButton = panel.transform.Find("Drop").gameObject;
			rect = GetComponent<RectTransform>();
		}

		public void BeginDrag()
		{
			oldParent = transform.parent;
			originalPos = rect.anchoredPosition;
			originalScale = rect.localScale;
			originalRot = transform.Find("image").localEulerAngles;
			transform.SetParent(transform.parent.parent);
			transform.SetAsLastSibling();
		}

		public void OnDrag(BaseEventData eventData)
		{
			var pointerData = eventData as PointerEventData;
			pointerData.useDragThreshold = true;

			var currentPosition = rect.anchoredPosition;
			currentPosition.x += pointerData.delta.x;
			currentPosition.y += pointerData.delta.y;
			rect.anchoredPosition = currentPosition;
		}

		public void EndDrag()
		{
			transform.SetParent(oldParent);
			if ( GetComponent<TriggerCheckerLITE>().triggeredInBag )
			{
				oldParent = transform.parent;
				transform.SetParent(GetComponent<TriggerCheckerLITE>().bagTrig);
			}
			else
			{
				if ( oldParent != transform.parent )
				{
					EventManager.OnItemDrag?.Invoke(this);
				}
				else
				{
					EventManager.OnItemDrag?.Invoke(this);
				}
				panel.GetComponent<RectTransform>().localScale = new Vector2(0, 0); //hides the panel without making it inactive so that future itemDrags don't crash
			}
			if ( GetComponent<TriggerCheckerLITE>().triggered == false &&
				Mathf.Round(rect.anchoredPosition.x / 50) * 50 <= ( 50 * transform.parent.GetComponent<InventoryGridScriptLITE>().width - 1 ) - ( 50 * ( transform.localScale.x - 1 ) ) &&
				Mathf.Round(rect.anchoredPosition.x / 50) * 50 >= 0 && 
				Mathf.Round(rect.anchoredPosition.y / 50) * 50 <= 0 &&
				Mathf.Round(rect.anchoredPosition.y / 50) * 50 >= -( 50 * transform.parent.GetComponent<InventoryGridScriptLITE>().height - 1 ) + ( 50 * ( transform.localScale.y - 1 ) ) )
			{
				rect.anchoredPosition = new Vector2(Mathf.Round(GetComponent<RectTransform>().anchoredPosition.x / 50) * 50, Mathf.Round(GetComponent<RectTransform>().anchoredPosition.y / 50) * 50);
				if ( oldParent != transform.parent )
				{
					EventManager.OnItemTransferFrom?.Invoke(this);
					EventManager.OnItemTransferTo?.Invoke(this);
				}
				else
				{
					EventManager.OnSortingSlots?.Invoke(this);
					originalPos = rect.anchoredPosition;
					originalRot = rect.transform.Find("image").localEulerAngles;
				}
			}
			else if ( GetComponent<TriggerCheckerLITE>().triggered == true || Mathf.Round(rect.anchoredPosition.x / 50) * 50 <= 50 * ( transform.parent.GetComponent<InventoryGridScriptLITE>().width - 1 ) )
			{
				transform.SetParent(oldParent);
				rect.anchoredPosition = originalPos;
				rect.localScale = originalScale;
				transform.Find("image").localEulerAngles = originalRot;
				GetComponent<TriggerCheckerLITE>().triggered = false;
			}
			else
			{
				if ( oldParent != transform.parent )
				{
					EventManager.OnItemDrag?.Invoke(this);
				}
				else
				{
					EventManager.OnItemDrag?.Invoke(this);
				}
				panel.GetComponent<RectTransform>().localScale = new Vector2(0, 0);
			}
			CheckIfEquipable();
		}

		private void Drop()
		{
			EventManager.OnItemDrag?.Invoke(this);
		}

		public void ReturnToNormal()
		{
			transform.SetParent(oldParent);
			rect.anchoredPosition = originalPos;
			rect.localScale = originalScale;
			transform.Find("image").localEulerAngles = originalRot;
			GetComponent<TriggerCheckerLITE>().triggered = false;
		}

		public void CheckIfEquipable()
		{
			panel.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
			panel.GetComponent<InventoryPanelLITE>().SelectItem(this);
			EventManager.OnItemDropping?.Invoke(transform.GetComponent<ItemDragLITE>());
			if ( obj.equipable )
			{
				equipButton.SetActive(true);
				EventManager.OnItemGiving?.Invoke(transform.GetComponent<ItemDragLITE>());
			}
			else
			{
				equipButton.SetActive(false);
			}
		}
	}
}