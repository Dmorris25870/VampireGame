using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

namespace VartraAbyss
{
    public class BindInkFunctions: MonoBehaviour
    {
		[SerializeField] private GameObject m_screenTint;

		[Header("Npc Characters")]
		[SerializeField] private GameObject BeatrixIntroPrefab;
		[SerializeField] private GameObject FirstFightPrefab;
		[SerializeField] private GameObject FirstPowerPrefab;
		[SerializeField] private GameObject AvoidPrefab;
		[SerializeField] private GameObject PetrPrefab;
		[SerializeField] private GameObject BarkeepPasswordPrefab;
		[SerializeField] private GameObject VictoriaIntroPrefab;
		[SerializeField] private GameObject IntercomFelixPrefab;
		[SerializeField] private GameObject BarkeepMessagePrefab;
		[SerializeField] private GameObject BeaGetsPowersPrefab;
		[SerializeField] private GameObject FelixFinalBattlePrefab;

		[SerializeField] private Dialogue_trigger m_playerTrigger;


		private void Awake()
		{
			m_screenTint.SetActive(false);
			m_playerTrigger.GetComponent<Dialogue_trigger>();
		}
		public void BindExternalFunction(Story story)
		{
			story.BindExternalFunction("ExplosionScreen" , (int number) =>
			{

				if( number <= 1 ) //if num is 1 turn on curtain
				{
					m_screenTint.SetActive(true);
					//Debug.Log("ExplosionScreenOn");
				}
				else if( number > 1 )//if num is 2 turn off curtain
				{
					m_screenTint.SetActive(false);
					//Debug.Log("ExplosionScreenOff");

				}

			});

			story.BindExternalFunction("CharacterEvent" , (int number) =>
			{
				if( number == 1 ) //Intro Bea 
				{
					BeatrixIntroPrefab.SetActive(false);
					ResetPlayerInRange();

				}
				else if( number == 2 ) //First fight
				{
					FirstFightPrefab.SetActive(false);
					ResetPlayerInRange();
				}
				else if( number == 3 ) //First power
				{
					FirstPowerPrefab.SetActive(false);
					ResetPlayerInRange();
				}
				else if( number == 4 ) //Turn off Petr and Avoid in Petr story
				{
					PetrPrefab.SetActive(false);
					AvoidPrefab.SetActive(false);
					ResetPlayerInRange();
				}
				else if( number == 5) //BarkeepPassword
				{
					BarkeepPasswordPrefab.SetActive(false);
					ResetPlayerInRange();
				}
				else if( number == 6 )//Meet Victoria
				{
					VictoriaIntroPrefab.SetActive(false);
					ResetPlayerInRange();
					//Turn on Basic barkeep prefab
				}
				else if( number == 7)
				{
					IntercomFelixPrefab.SetActive(false);
					ResetPlayerInRange();
					//Turn off Basic barkeep
					//Turn on Barkeep message npc
				}

			});
		}

		public void Unbind(Story story)
		{
			story.UnbindExternalFunction("ExplosionScreen");
			story.UnbindExternalFunction("CharacterEvent");
		}

		public void ResetPlayerInRange()
		{
			m_playerTrigger.playerInRange = false;
		}
	}
}
