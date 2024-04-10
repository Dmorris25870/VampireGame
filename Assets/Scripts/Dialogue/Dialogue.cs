using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss.Dialogue
{
	public class Dialogue : MonoBehaviour
	{
		[SerializeField] private string m_speakerName;
		[SerializeField] private Image m_speakerPortrait;

		[TextArea(5,10)]
		[SerializeField] private string m_dialogue;
	}
}