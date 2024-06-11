using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform m_draggingObject;
    private bool m_canSet;
    private Image m_draggingObjectImage;
    private GameObject m_activeSkillSlot;

    private void Awake()
    {
        m_draggingObject = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        m_draggingObjectImage = m_draggingObject.GetComponent<Image>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(m_canSet)
        {
            m_activeSkillSlot.GetComponent<Image>().sprite = m_draggingObjectImage.sprite;
            m_activeSkillSlot.GetComponentInChildren<Image>().sprite = m_draggingObjectImage.sprite;
            gameObject.transform.localPosition = gameObject.transform.parent.localPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            m_draggingObjectImage = null;
        }
        else if (!m_canSet)//return to old parent
        {
            gameObject.transform.localPosition = gameObject.transform.parent.localPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SkillSlot"))
        {
            m_canSet = true;
            m_activeSkillSlot = collision.gameObject;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SkillSlot"))
        {
            m_canSet = false;
        }
    }
}
