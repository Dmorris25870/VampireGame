using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss.UI
{
    public class UIViewer : MonoBehaviour
    {
		[SerializeField] private Canvas m_statsUI;
		[SerializeField] private TextMeshProUGUI m_vitalityNumber;
		[SerializeField] private TextMeshProUGUI m_mindNumber;
		[SerializeField] private TextMeshProUGUI m_strengthNumber;
		[SerializeField] private TextMeshProUGUI m_dexterityNumber;
		[SerializeField] private TextMeshProUGUI m_statPointsNumber;
		[SerializeField] private Button m_vitalityIncreaseButton;
		[SerializeField] private Button m_vitalityDecreaseButton;
		[SerializeField] private Button m_mindIncreaseButton;
		[SerializeField] private Button m_mindDecreaseButton;
		[SerializeField] private Button m_strengthIncreaseButton;
		[SerializeField] private Button m_strengthDecreaseButton;
		[SerializeField] private Button m_dexterityIncreaseButton;
		[SerializeField] private Button m_dexterityDecreaseButton;

		public void UpdateUI(int vitality, int mind, int strength, int dexterity, int statPoints)
		{
			m_vitalityNumber.text = vitality.ToString();
			m_mindNumber.text = mind.ToString();
			m_strengthNumber.text = strength.ToString();
			m_dexterityNumber.text = dexterity.ToString();
			m_statPointsNumber.text = string.Format($"{statPoints} points remaining.");
		}

		public void ToggleVitalityIncreaseButton(bool enabled)
		{
			m_vitalityIncreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleVitalityDecreaseButton(bool enabled)
		{
			m_vitalityDecreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleMindIncreaseButton(bool enabled)
		{
			m_mindIncreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleMindDecreaseButton(bool enabled)
		{
			m_mindDecreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleStrengthIncreaseButton(bool enabled)
		{
			m_strengthIncreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleStrengthDecreaseButton(bool enabled)
		{
			m_strengthDecreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleDexterityIncreaseButton(bool enabled)
		{
			m_dexterityIncreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleDexterityDecreaseButton(bool enabled)
		{
			m_dexterityDecreaseButton.gameObject.SetActive(enabled);
		}

		public void ToggleAllIncreaseButtons(bool enabled)
		{
			ToggleVitalityIncreaseButton(enabled);
			ToggleMindIncreaseButton(enabled);
			ToggleStrengthIncreaseButton(enabled);
			ToggleDexterityIncreaseButton(enabled);
		}

		public void ToggleAllDecreaseButtons(bool enabled)
		{
			ToggleVitalityDecreaseButton(enabled);
			ToggleMindDecreaseButton(enabled);
			ToggleStrengthDecreaseButton(enabled);
			ToggleDexterityDecreaseButton(enabled);
		}
	}
}