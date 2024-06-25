using UnityEngine;
using UnityEngine.EventSystems;

namespace VartraAbyss
{
	public class MenuDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] private GameObject m_menuToDrag;
		[SerializeField] private GameObject m_canvas;
		[SerializeField] private GameObject m_dragParent;
		private Vector2 m_offset;

		public void OnBeginDrag(PointerEventData eventData)
		{
			if( eventData.pointerCurrentRaycast.gameObject is GameObject target )
			{
				MenuDrag targetMenu = target.GetComponent<MenuDrag>();
				if( targetMenu != null )
				{
					RectTransformUtility.ScreenPointToLocalPointInRectangle(m_menuToDrag.GetComponent<RectTransform>() , eventData.position , eventData.pressEventCamera , out m_offset);

					m_dragParent = new GameObject("Drag Instance " + m_menuToDrag.name);
					m_dragParent.transform.SetParent(m_canvas.transform);
					m_dragParent.transform.SetAsLastSibling();
					m_dragParent.transform.position = m_menuToDrag.transform.position;
					m_menuToDrag.transform.SetParent(m_dragParent.transform);
				}
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if( m_dragParent != null )
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(m_canvas.GetComponent<RectTransform>() , eventData.position , eventData.pressEventCamera , out Vector2 localPoint);
				m_dragParent.transform.localPosition = localPoint - m_offset;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if( m_dragParent != null )
			{
				m_menuToDrag.transform.SetParent(m_canvas.transform);
				m_menuToDrag.transform.position = m_dragParent.transform.position;
				Destroy(m_dragParent);
			}
		}
	}
}
