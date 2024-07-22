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

		private void Awake()
		{
			m_screenTint.SetActive(false);
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
				if( number <= 1 )
				{
					Debug.Log("PeaceOut");
				}
			});
		}

		public void CharacterEventsKeeper(Story story)
		{
			story.BindExternalFunction("CharacterEvent" , (int number) =>
				{

				});
		}

		public void Unbind(Story story)
		{
			story.UnbindExternalFunction("ExplosionScreen");
		}
	}
}
