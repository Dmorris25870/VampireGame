using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using VartraAbyss.Actions;
using System;


namespace VartraAbyss.Dialogue
{
	[System.Serializable]
	public class DialogueSystem : MonoBehaviour
	{
		[Header("Dialogue UI")]
		[SerializeField] private GameObject dialogueBox;
		[SerializeField] private TextMeshProUGUI dialoguetext;
		[SerializeField] private TextMeshProUGUI npcNameText;


		//[SerializeField] private TextAsset m_inkTextFile;
		//[SerializeField] private Story m_currentStory;
		[SerializeField] private Story currentStory;
		private static Dialogue_trigger dialogue_trigger;
		//[SerializeField] private List<Dialogue> m_listOfDialogues = new List<Dialogue>();

		private static DialogueSystem instance;
		public bool dialogueIsPlaying {get; private set;}
		[SerializeField] public InputActionReference letsTalk;
		public static bool talkBool;
		//public Action actionScript;

		private void Awake()
		{
			if (instance != null)
			{
				Debug.LogWarning("Found more than one Dialogue system");
			}
			instance = this;
		}

		public static DialogueSystem GetInstance()
		{
			return instance;
		}

		public static Dialogue_trigger GetDTInstance()
		{
			return dialogue_trigger;
		}
		private void OnEnable()
		{
			letsTalk.action.performed += PerformTalk;
		}

		public void PerformTalk(InputAction.CallbackContext context)
		{
			talkBool = true;

        }

        private void OnDisable()
		{
			letsTalk.action.performed -= PerformTalk;
		}

		private void Start()
		{
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
            //npcNameText.text = dialogue_trigger.npcName;

        }

		private void Update()
		{
			if (!dialogueIsPlaying)
			{
				return;
			}

		}

		public void EnterDialogueMode(TextAsset inkJSON)
		{
			currentStory = new Story(inkJSON.text);
			dialogueIsPlaying = true;
			//npcNameText.text = npcNameText.transform.GetComponent<TextMeshProUGUI>().text;
            //npcNameText.text = dialogue_trigger.npcName;
			dialogueBox.SetActive(true);

            ContinueStory();

		}

		private void ExitDialogueMode()
		{
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
			dialoguetext.text = "";
		}

		public void ContinueStory()
		{
			if (currentStory.canContinue)
			{
				dialoguetext.text = currentStory.Continue();
			}
			else
			{
				ExitDialogueMode();
			}
		}

	}
}