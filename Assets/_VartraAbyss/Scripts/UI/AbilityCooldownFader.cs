using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss
{
	public class AbilityCooldownFader : MonoBehaviour
	{
		[SerializeField] private UISlot[] m_slots;

		[field: SerializeField] public bool[] AbilitiesCoolingDown { get; private set; }

		private void OnEnable()
		{
			m_slots = GetComponentsInChildren<UISlot>();
			AbilitiesCoolingDown = new bool[m_slots.Length];
			EventManager.OnActivatedSlot1Ability += OnSlot1AbilityActivated;
			EventManager.OnActivatedSlot2Ability += OnSlot2AbilityActivated;
			EventManager.OnActivatedSlot3Ability += OnSlot3AbilityActivated;
			EventManager.OnActivatedSlot4Ability += OnSlot4AbilityActivated;
			EventManager.OnActivatedSlot5Ability += OnSlot5AbilityActivated;
			EventManager.OnActivatedSlot6Ability += OnSlot6AbilityActivated;
			EventManager.OnActivatedSlot7Ability += OnSlot7AbilityActivated;
		}

		private void OnDisable()
		{
			EventManager.OnActivatedSlot1Ability -= OnSlot1AbilityActivated;
			EventManager.OnActivatedSlot2Ability -= OnSlot2AbilityActivated;
			EventManager.OnActivatedSlot3Ability -= OnSlot3AbilityActivated;
			EventManager.OnActivatedSlot4Ability -= OnSlot4AbilityActivated;
			EventManager.OnActivatedSlot5Ability -= OnSlot5AbilityActivated;
			EventManager.OnActivatedSlot6Ability -= OnSlot6AbilityActivated;
			EventManager.OnActivatedSlot7Ability -= OnSlot7AbilityActivated;
			m_slots = null;
			AbilitiesCoolingDown = null;
		}

		private void OnSlot1AbilityActivated() => StartAbilityCooldown(0);
		private void OnSlot2AbilityActivated() => StartAbilityCooldown(1);
		private void OnSlot3AbilityActivated() => StartAbilityCooldown(2);
		private void OnSlot4AbilityActivated() => StartAbilityCooldown(3);
		private void OnSlot5AbilityActivated() => StartAbilityCooldown(4);
		private void OnSlot6AbilityActivated() => StartAbilityCooldown(5);
		private void OnSlot7AbilityActivated() => StartAbilityCooldown(6);

		private void StartAbilityCooldown(int slotIndex)
		{
			if(m_slots == null || m_slots.Length <= slotIndex || AbilitiesCoolingDown == null)
			{
				Debug.LogError("Invalid state: m_slots or AbilitiesCoolingDown is not initialized properly.");
				return;
			}

			if(!AbilitiesCoolingDown[slotIndex])
			{
				EventManager.OnReturnUsedAbility?.Invoke(null , m_slots[slotIndex].storage.GetItem(slotIndex).abilityName);

				if(this != null)
				{
					StartCoroutine(AbilityCooldownCoroutine(slotIndex));
				}
			}
		}

		private IEnumerator AbilityCooldownCoroutine(int slotIndex)
		{
			AbilitiesCoolingDown[slotIndex] = true;
			m_slots[slotIndex].isStatic = true;
			float abilityCoolDown = m_slots[slotIndex].storage.GetItem(slotIndex).coolDownTime;
			Image abilityImage = m_slots[slotIndex].itemImage.GetComponentInChildren<Image>();
			abilityImage.fillAmount = 0;
			Color color = abilityImage.color;
			color.a = 0.5f;
			abilityImage.color = color;

			while(abilityImage.fillAmount < 1)
			{
				abilityImage.fillAmount += 1.0f / abilityCoolDown * Time.deltaTime;
				yield return null;
			}

			AbilitiesCoolingDown[slotIndex] = false;
			m_slots[slotIndex].isStatic = false;
			color.a = 1;
			abilityImage.color = color;
		}
	}
}
