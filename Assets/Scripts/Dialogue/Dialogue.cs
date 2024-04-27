using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

namespace VartraAbyss.Dialogue
{	
	[System.Serializable]
	public class Dialogue : MonoBehaviour
	{
		[SerializeField] private Profile m_speakerOne;
		[SerializeField] private Profile m_speakerTwo;

		[SerializeField] private bool m_isInkBased;

		[SerializeField] private string m_simpleDialogue;
		[SerializeField] private Story m_inkDialogue;
	}
}