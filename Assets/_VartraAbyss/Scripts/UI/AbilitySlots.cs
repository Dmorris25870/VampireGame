using UnityEngine;
using UnityEngine.UI;
using VartraAbyss;

public class AbilitySlots : Storage
{
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
		Debug.Log("UI slot is being updated.");
		if( slots[0].GetComponent<Image>().fillAmount < 1 )
		{
			slots[0].GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
		}
		else if( slots[0].GetComponent<Image>().fillAmount >= 1 )
		{
			ability1Cooling = false;
			Color a = slots[0].GetComponent<Image>().color;
			a.a = 1;
			slots[0].GetComponent<Image>().color = a;
		}

		if( slots[1].GetComponent<Image>().fillAmount < 1 )
		{
			slots[1].GetComponent<Image>().fillAmount += 1.0f / waitTime * Time.deltaTime;
		}
		else if( slots[1].GetComponent<Image>().fillAmount >= 1 )
		{
			ability2Cooling = false;
			Color a = slots[1].GetComponent<Image>().color;
			a.a = 1;
			slots[1].GetComponent<Image>().color = a;
		}
	}


	private void QAbilityUsedVisual()
	{
		if( ability1Cooling )
		{
			return;
		}
		else
		{
			Debug.Log("Cooldown is active.");
			Debug.Log($"{slots[0].GetComponent<Image>().name} is the image being pulled through.");
			slots[0].GetComponent<Image>().fillAmount = 0;
			Color a = slots[0].GetComponent<Image>().color;
			a.a = 0.5f;
			slots[0].GetComponent<Image>().color = a;
			ability1Cooling = true;
		}
	}

	private void WAbilityUsedVisual()
	{
		if( ability2Cooling )
		{
			return;
		}
		else
		{
			slots[1].GetComponent<Image>().fillAmount = 0;
			Color a = slots[1].GetComponent<Image>().color;
			a.a = 0.5f;
			slots[1].GetComponent<Image>().color = a;
			ability2Cooling = true;
		}
	}
}
