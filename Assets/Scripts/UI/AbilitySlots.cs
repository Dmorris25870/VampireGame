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

    private void OnEnable()
    {
        EventManager.OnQAbility += Ability1UsedVisual;
    }

    private void OnDisable()
    {
        EventManager.OnQAbility -= Ability1UsedVisual;

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
        }
    }


    private void Ability1UsedVisual()
    {
        if (Ability1Cooling)
        {
            return;
        }
        else
        {
            Slot1.GetComponent<Image>().fillAmount = 0;
            Ability1Cooling = true;
        }
                
    }    
}
