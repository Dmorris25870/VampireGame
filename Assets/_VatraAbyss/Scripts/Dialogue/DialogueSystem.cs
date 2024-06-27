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

		[Header("Choice UI")]
		[SerializeField] private GameObject[] choices;
		private TextMeshProUGUI[] choicesText;

		[Header("Params")]
		[SerializeField] private float typingSpeed = 0.04f;

        //[SerializeField] private TextAsset m_inkTextFile;
        //[SerializeField] private Story m_currentStory;
        [SerializeField] private Story currentStory;
		[SerializeField] private Dialogue_trigger dialogue_trigger;
		//[SerializeField] private List<Dialogue> m_listOfDialogues = new List<Dialogue>();

		private static DialogueSystem instance;
		public bool dialogueIsPlaying {get; private set;}
		[SerializeField] public InputActionReference letsTalk;
		public static bool talkBool;
		private Coroutine displayLineCoroutine;
		private bool canContinueToNextLine = false;

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
			Debug.Log(dialogue_trigger.npcName);
			Debug.Log(npcNameText.text);
            npcNameText.text = dialogue_trigger.npcName;
            dialogueBox.SetActive(false);
			

			InitialiseChoices();
        }

		private void InitialiseChoices()
		{
			choicesText = new TextMeshProUGUI[choices.Length];
			int index = 0;

			foreach (GameObject choice in choices)
			{
				choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
				index++;
			}
		}

		private void DisplayChoices()
		{
			List<Choice> currentChoices = currentStory.currentChoices;

			if (currentChoices.Count > choices.Length)
			{
				Debug.Log("Unsupported amount of choices " + currentChoices.Count);
			}

			int index = 0;
			foreach (Choice choice in currentChoices)
			{
				choices[index].gameObject.SetActive(true);
				choicesText[index].text = choice.text;
				index++;

			}

			for (int i = index; i < choices.Length; i++)
			{
				choices[i].gameObject.SetActive(false);
			}

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

		private IEnumerator DisplayLine(string line)
		{
			dialoguetext.text = "";

			canContinueToNextLine = false;

			foreach (char letter in line.ToCharArray())
			{
				dialoguetext.text += letter;
				yield return new WaitForSeconds(typingSpeed);

            }

			canContinueToNextLine = true;
		}
		private void ExitDialogueMode()
		{
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
			dialoguetext.text = "";
			talkBool = false;
		}

		public void ContinueStory()
		{
			if (//canContinueToNextLine && 
				currentStory.canContinue)
			{
				if(displayLineCoroutine !=null) 
				{ 
					StopCoroutine(displayLineCoroutine);
				}
				displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
				DisplayChoices();
				Debug.Log("can continue story");
			}
			else
			{
				ExitDialogueMode();
			}
		}

	}
}