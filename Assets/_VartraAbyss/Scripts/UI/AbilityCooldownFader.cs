using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss
{
	public class AbilityCooldownFader : MonoBehaviour
	{
		[SerializeField] private UISlot[] m_slots;

		public bool[] AbilitiesCoolingDown { get; private set; }

		private void OnEnable()
		{
			EventManager.OnActivatedSlot1Ability += () => StartAbilityCooldown(0);
			EventManager.OnActivatedSlot2Ability += () => StartAbilityCooldown(1);
			EventManager.OnActivatedSlot3Ability += () => StartAbilityCooldown(2);
			EventManager.OnActivatedSlot4Ability += () => StartAbilityCooldown(3);
			EventManager.OnActivatedSlot5Ability += () => StartAbilityCooldown(4);
			EventManager.OnActivatedSlot6Ability += () => StartAbilityCooldown(5);
			EventManager.OnActivatedSlot7Ability += () => StartAbilityCooldown(6);
		}

		private void OnDisable()
		{
			EventManager.OnActivatedSlot1Ability -= () => StartAbilityCooldown(0);
			EventManager.OnActivatedSlot2Ability -= () => StartAbilityCooldown(1);
			EventManager.OnActivatedSlot3Ability -= () => StartAbilityCooldown(2);
			EventManager.OnActivatedSlot4Ability -= () => StartAbilityCooldown(3);
			EventManager.OnActivatedSlot5Ability -= () => StartAbilityCooldown(4);
			EventManager.OnActivatedSlot6Ability -= () => StartAbilityCooldown(5);
			EventManager.OnActivatedSlot7Ability -= () => StartAbilityCooldown(6);
		}

		private void Start()
		{
			AbilitiesCoolingDown = new bool[m_slots.Length];
		}

		private void StartAbilityCooldown(int slotIndex)
		{
			if( !AbilitiesCoolingDown[slotIndex] )
			{
				// GET UI SLOT INDEX
				EventManager.OnReturnUsedAbility?.Invoke(null , m_slots[slotIndex].storage.GetItem(slotIndex).abilityName);
				StartCoroutine(AbilityCooldownCoroutine(slotIndex));
			}
		}

		private IEnumerator AbilityCooldownCoroutine(int slotIndex)
		{
			AbilitiesCoolingDown[slotIndex] = true;
			float abilityCoolDown = m_slots[slotIndex].storage.GetItem(slotIndex).coolDownTime;
			Image abilityImage = m_slots[slotIndex].itemImage.GetComponentInChildren<Image>();
			abilityImage.fillAmount = 0;
			Color color = abilityImage.color;
			color.a = 0.5f;
			abilityImage.color = color;

			while( abilityImage.fillAmount < 1 )
			{
				abilityImage.fillAmount += 1.0f / abilityCoolDown * Time.deltaTime;
				yield return null;
			}

			AbilitiesCoolingDown[slotIndex] = false;
			color.a = 1;
			abilityImage.color = color;
		}
	}
}
