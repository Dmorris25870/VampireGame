using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform draggingObject;
    private bool canSet;
    private Image draggingObjectImage;
    private GameObject activeSkillSlot;

    private void Awake()
    {
        draggingObject = transform as RectTransform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        draggingObjectImage = draggingObject.GetComponent<Image>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(canSet)
        {
            activeSkillSlot.GetComponent<Image>().sprite = draggingObjectImage.sprite;
            activeSkillSlot.GetComponentInChildren<Image>().sprite = draggingObjectImage.sprite;
            gameObject.transform.localPosition = gameObject.transform.parent.localPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
            draggingObjectImage = null;
        }
        else if (!canSet)//return to old parent
        {
            gameObject.transform.localPosition = gameObject.transform.parent.localPosition;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SkillSlot"))
        {
            canSet = true;
            activeSkillSlot = collision.gameObject;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SkillSlot"))
        {
            canSet = false;
        }
    }
}
