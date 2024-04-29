using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Stats;

namespace VartraAbyss.UI
{
    public class UIPresenter : MonoBehaviour
    {
		[SerializeField] private StatScriptableObject m_statsToDisplay;
		[SerializeField] private UIViewer m_uiViewer;

		private void Start()
		{
			RefreshUI();
		}

		public void IncreaseVitality()
		{
			m_statsToDisplay.vitality++;
			m_statsToDisplay.currentStatPointPool--;
			RefreshUI();
		}

		public void DecreaseVitality()
		{
			m_statsToDisplay.vitality--;
			m_statsToDisplay.currentStatPointPool++;
			RefreshUI();
		}

		public void IncreaseMind()
		{
			m_statsToDisplay.mind++;
			m_statsToDisplay.currentStatPointPool--;
			RefreshUI();
		}

		public void DecreaseMind()
		{
			m_statsToDisplay.mind--;
			m_statsToDisplay.currentStatPointPool++;
			RefreshUI();
		}

		public void IncreaseStrength()
		{
			m_statsToDisplay.strength++;
			m_statsToDisplay.currentStatPointPool--;
			RefreshUI();
		}

		public void DecreaseStrength()
		{
			m_statsToDisplay.strength--;
			m_statsToDisplay.currentStatPointPool++;
			RefreshUI();
		}

		public void IncreaseDexterity()
		{
			m_statsToDisplay.dexterity++;
			m_statsToDisplay.currentStatPointPool--;
			RefreshUI();
		}

		public void DecreaseDexterity()
		{
			m_statsToDisplay.dexterity--;
			m_statsToDisplay.currentStatPointPool++;
			RefreshUI();
		}

		private void RefreshUI()
		{
			m_uiViewer.ToggleAllDecreaseButtons(true);
			m_uiViewer.ToggleAllIncreaseButtons(true);

			m_uiViewer.UpdateUI(m_statsToDisplay.vitality ,
								m_statsToDisplay.mind ,
								m_statsToDisplay.strength ,
								m_statsToDisplay.dexterity ,
								m_statsToDisplay.currentStatPointPool);

			if(m_statsToDisplay.currentStatPointPool <= 0)
			{
				m_uiViewer.ToggleAllIncreaseButtons(false);
			}

			if(m_statsToDisplay.vitality >= 20)
			{
				m_uiViewer.ToggleVitalityIncreaseButton(false);
			}

			if(m_statsToDisplay.vitality <= 0)
			{
				m_uiViewer.ToggleVitalityDecreaseButton(false);
			}

			if( m_statsToDisplay.mind >= 20 )
			{
				m_uiViewer.ToggleMindIncreaseButton(false);
			}

			if( m_statsToDisplay.mind <= 0 )
			{
				m_uiViewer.ToggleMindDecreaseButton(false);
			}

			if( m_statsToDisplay.strength >= 20 )
			{
				m_uiViewer.ToggleStrengthIncreaseButton(false);
			}
			if( m_statsToDisplay.strength <= 0 )
			{
				m_uiViewer.ToggleStrengthDecreaseButton(false);
			}

			if( m_statsToDisplay.dexterity >= 20 )
			{
				m_uiViewer.ToggleDexterityIncreaseButton(false);
			}
			if( m_statsToDisplay.dexterity <= 0 )
			{
				m_uiViewer.ToggleDexterityDecreaseButton(false);
			}
		}
	}
}