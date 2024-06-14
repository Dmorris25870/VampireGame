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

		private Dictionary<string , TextMeshProUGUI> m_statTexts;
		private Dictionary<string , Button> m_increaseButtons;
		private Dictionary<string , Button> m_decreaseButtons;

		private void Awake()
		{
			m_statTexts = new Dictionary<string , TextMeshProUGUI>()
		{
			{ "Vitality", m_vitalityNumber },
			{ "Mind", m_mindNumber },
			{ "Strength", m_strengthNumber },
			{ "Dexterity", m_dexterityNumber }
		};

			m_increaseButtons = new Dictionary<string , Button>()
		{
			{ "Vitality", m_vitalityIncreaseButton },
			{ "Mind", m_mindIncreaseButton },
			{ "Strength", m_strengthIncreaseButton },
			{ "Dexterity", m_dexterityIncreaseButton }
		};

			m_decreaseButtons = new Dictionary<string , Button>()
		{
			{ "Vitality", m_vitalityDecreaseButton },
			{ "Mind", m_mindDecreaseButton },
			{ "Strength", m_strengthDecreaseButton },
			{ "Dexterity", m_dexterityDecreaseButton }
		};
		}

		public void UpdateUI(int vitality , int mind , int strength , int dexterity , int statPoints)
		{
			m_statTexts["Vitality"].text = vitality.ToString();
			m_statTexts["Mind"].text = mind.ToString();
			m_statTexts["Strength"].text = strength.ToString();
			m_statTexts["Dexterity"].text = dexterity.ToString();
			m_statPointsNumber.text = $"{statPoints} points remaining.";
		}

		public void ToggleButton(string statName , bool enabled , bool isIncrease)
		{
			if( isIncrease )
			{
				if( m_increaseButtons.ContainsKey(statName) )
				{
					m_increaseButtons[statName].gameObject.SetActive(enabled);
				}
			}
			else
			{
				if( m_decreaseButtons.ContainsKey(statName) )
				{
					m_decreaseButtons[statName].gameObject.SetActive(enabled);
				}
			}
		}

		public void ToggleVitalityIncreaseButton(bool enabled) => ToggleButton("Vitality" , enabled , true);
		public void ToggleVitalityDecreaseButton(bool enabled) => ToggleButton("Vitality" , enabled , false);
		public void ToggleMindIncreaseButton(bool enabled) => ToggleButton("Mind" , enabled , true);
		public void ToggleMindDecreaseButton(bool enabled) => ToggleButton("Mind" , enabled , false);
		public void ToggleStrengthIncreaseButton(bool enabled) => ToggleButton("Strength" , enabled , true);
		public void ToggleStrengthDecreaseButton(bool enabled) => ToggleButton("Strength" , enabled , false);
		public void ToggleDexterityIncreaseButton(bool enabled) => ToggleButton("Dexterity" , enabled , true);
		public void ToggleDexterityDecreaseButton(bool enabled) => ToggleButton("Dexterity" , enabled , false);

		public void ToggleAllIncreaseButtons(bool enabled)
		{
			foreach( var button in m_increaseButtons.Values )
			{
				button.gameObject.SetActive(enabled);
			}
		}

		public void ToggleAllDecreaseButtons(bool enabled)
		{
			foreach( var button in m_decreaseButtons.Values )
			{
				button.gameObject.SetActive(enabled);
			}
		}
	}
}