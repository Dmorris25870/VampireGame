using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VartraAbyss.Dialogue
{
	[System.Serializable]
	public class Profile : MonoBehaviour
	{
		[SerializeField] private string m_profileName;
		[SerializeField] private Image m_profileImage;

		public string ProfileName { get { return m_profileName; } }
		public Image ProfileImage { get { return m_profileImage; } }
	}
}