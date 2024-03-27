using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlots : MonoBehaviour
{
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;    
    public GameObject Slot4;
    public GameObject Slot5;
    public GameObject Slot6;
    public GameObject Slot7;
    public GameObject Slot8;
    public GameObject Slot9;

    public float waitTime = 5f;
    public bool Ability1Cooling;
    public bool Ability2Cooling;

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
        if(Slot1.GetComponent<Image>().fillAmount < 1) 
        {
            Slot1.GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else if(Slot1.GetComponent<Image>().fillAmount >= 1)
        {
            Ability1Cooling = false;
            var a = Slot1.GetComponent<Image>().color;
            a.a = 1;
            Slot1.GetComponent<Image>().color = a;
        }

        if (Slot2.GetComponent<Image>().fillAmount < 1)
        {
            Slot2.GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
        }
        else if (Slot2.GetComponent<Image>().fillAmount >= 1)
        {
            Ability2Cooling = false;
            var a = Slot2.GetComponent<Image>().color;
            a.a = 1;
            Slot2.GetComponent<Image>().color = a;
        }
    }


    private void QAbilityUsedVisual()
    {
        if (Ability1Cooling)
        {
            return;
        }
        else
        {
            Slot1.GetComponent<Image>().fillAmount = 0;
            var a = Slot1.GetComponent<Image>().color;
            a.a = 0.5f;
            Slot1.GetComponent<Image>().color = a;
            Ability1Cooling = true;
        }                
    }

    private void WAbilityUsedVisual()
    {
        if (Ability2Cooling)
        {
            return;
        }
        else
        {
            Slot2.GetComponent<Image>().fillAmount = 0;
            var a = Slot2.GetComponent<Image>().color;
            a.a = 0.5f;
            Slot2.GetComponent<Image>().color = a;
            Ability2Cooling = true;
        }
    }
}
