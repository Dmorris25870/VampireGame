using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

namespace VartraAbyss.Dialogue
{
	[System.Serializable]
	public class DialogueSystem : MonoBehaviour
	{
		[SerializeField] private TextAsset m_inkTextFile;
		[SerializeField] private Story m_currentStory;
		[SerializeField] private List<Dialogue> m_listOfDialogues = new List<Dialogue>();
	}
}