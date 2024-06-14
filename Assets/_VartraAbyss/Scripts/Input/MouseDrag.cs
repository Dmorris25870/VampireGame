using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VartraAbyss.Utility;

namespace VartraAbyss
{
	public class MouseDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		Storage m_storage;
		UISlot m_uiSlot;
		GameObject m_dragInstance;

		public void SetupStorage(Storage storage , UISlot uiSlot)
		{
			this.m_storage = storage;
			this.m_uiSlot = uiSlot;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			m_storage.SwapItem(m_uiSlot);

			m_dragInstance = new GameObject("Drag Instance " + m_uiSlot.name);
			Image image = m_dragInstance.GetOrAdd<Image>();

			image.sprite = m_uiSlot.itemImage.sprite;
			image.raycastTarget = false;

			m_dragInstance.transform.SetParent(m_storage.transform);
			m_dragInstance.transform.localScale = Vector3.one;
		}

		public void OnDrag(PointerEventData eventData)
		{
			if( m_dragInstance != null )
			{
				m_dragInstance.transform.position = Input.mousePosition;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if( eventData.pointerCurrentRaycast.gameObject is GameObject target )
			{
				UISlot targetSlot = target.GetComponentInParent<UISlot>();

				if( targetSlot != null )
				{
					m_storage.SwapItem(targetSlot);
					EventSystem.current.SetSelectedGameObject(target);
				}
			}

			m_storage.ClearSwap();

			if( m_dragInstance != null )
			{
				Destroy(m_dragInstance);
			}
		}
	}
}
