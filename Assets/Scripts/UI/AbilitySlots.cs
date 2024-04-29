using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlots : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;    
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    public GameObject slot7;
    public GameObject slot8;
    public GameObject slot9;

    public float waitTime = 5f;
    public bool ability1Cooling;
    public bool ability2Cooling;

    private void OnEnable()
    {
        EventManager.OnQAbility += QAbilityUsedVisual;
        EventManager.OnWAbility += WAbilityUsedVisual;
    }

    private void OnDisable()
    {
        EventManager.OnQAbility -= QAbilityUsedVisual;
        EventManager.OnWAbility -= WAbilityUsedVisual;
    }

    private void Update()
    {
        if(slot1.GetComponent<Image>().fillAmount < 1) 
        {
            slot1.GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else if(slot1.GetComponent<Image>().fillAmount >= 1)
        {
            ability1Cooling = false;
			Color a = slot1.GetComponent<Image>().color;
            a.a = 1;
            slot1.GetComponent<Image>().color = a;
        }

        if (slot2.GetComponent<Image>().fillAmount < 1)
        {
            slot2.GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else if (slot2.GetComponent<Image>().fillAmount >= 1)
        {
            ability2Cooling = false;
			Color a = slot2.GetComponent<Image>().color;
            a.a = 1;
            slot2.GetComponent<Image>().color = a;
        }
    }


    private void QAbilityUsedVisual()
    {
        if (ability1Cooling)
        {
            return;
        }
        else
        {
            slot1.GetComponent<Image>().fillAmount = 0;
			Color a = slot1.GetComponent<Image>().color;
            a.a = 0.5f;
            slot1.GetComponent<Image>().color = a;
            ability1Cooling = true;
        }                
    }

    private void WAbilityUsedVisual()
    {
        if (ability2Cooling)
        {
            return;
        }
        else
        {
            slot2.GetComponent<Image>().fillAmount = 0;
            Color a = slot2.GetComponent<Image>().color;
            a.a = 0.5f;
            slot2.GetComponent<Image>().color = a;
            ability2Cooling = true;
        }
    }
}
