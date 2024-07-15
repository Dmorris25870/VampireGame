using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


namespace VartraAbyss.Dialogue
{
	[System.Serializable]
	public class DialogueSystem : MonoBehaviour
	{
		[Header("Dialogue UI")]
		[SerializeField] private GameObject dialogueBox;
		[SerializeField] private TextMeshProUGUI dialoguetext;
		[SerializeField] private TextMeshProUGUI npcNameText;
		[SerializeField] private Animator portraitAnimator;
		private Animator layoutAnimator;

		[Header("Choice UI")]
		[SerializeField] private GameObject[] choices;
		private TextMeshProUGUI[] choicesText;

		[Header("Params")]
		[SerializeField] private float typingSpeed = 0.04f;

		//[SerializeField] private TextAsset m_inkTextFile;
		//[SerializeField] private Story m_currentStory;
		[SerializeField] private Story currentStory;
		[SerializeField] private DialogueHolder dialogueHolder;
		[SerializeField] private Dialogue_trigger dialogue_Trigger;
		//[SerializeField] private List<Dialogue> m_listOfDialogues = new List<Dialogue>();

		private static DialogueSystem instance;
		public bool dialogueIsPlaying { get; private set; }
		[SerializeField] public InputActionReference letsTalk;
		public static bool talkBool;
		private Coroutine displayLineCoroutine;
		private bool canContinueToNextLine = false;
		public GameObject dHolder;
		//private bool onSkipPrint;

		private const string SPEAKER_TAG = "speaker";
		private const string PORTRAIT_TAG = "portrait";
		private const string LAYOUT_TAG = "layout";

		private void OnEnable()
		{
			letsTalk.action.performed += PerformTalk;
		}

		private void OnDisable()
		{
			letsTalk.action.performed -= PerformTalk;
			//Debug.Log("Enable talk");
		}

		private void Start()
		{
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
			//InitialiseChoices();
			layoutAnimator = dialogueBox.GetComponent<Animator>();
		}

		public void PerformTalk(InputAction.CallbackContext context)
		{
	
			if( dialogue_Trigger.playerInRange )
			{
				EnterDialogueMode(dialogue_Trigger.inkJSON);
			}
			else
			{
				//Debug.Log("No talky");
			}

		}

		public static DialogueSystem GetInstance()
		{
			return instance;
		}

		//private void InitialiseChoices()
		//{
		//	choicesText = new TextMeshProUGUI[choices.Length];
		//	int index = 0;

		//	foreach (GameObject choice in choices)
		//	{
		//		choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
		//		index++;
		//	}
		//}

		//private void DisplayChoices()
		//{
		//	List<Choice> currentChoices = currentStory.currentChoices;

		//	if (currentChoices.Count > choices.Length)
		//	{
		//		Debug.Log("Unsupported amount of choices " + currentChoices.Count);
		//	}

		//	int index = 0;
		//	foreach (Choice choice in currentChoices)
		//	{
		//		choices[index].gameObject.SetActive(true);
		//		choicesText[index].text = choice.text;
		//		index++;

		//	}

		//	for (int i = index; i < choices.Length; i++)
		//	{
		//		choices[i].gameObject.SetActive(false);
		//	}

		//}

		private void Update()
		{
			if( !dialogueIsPlaying )
			{
				return;
			}

		}

		public void EnterDialogueMode(TextAsset inkJSON)
		{
			dialogueHolder = dHolder.GetComponent<DialogueHolder>();
			Debug.Log(dHolder);
			//npcNameText.text = dialogueHolder.npcName;
			Debug.Log(npcNameText.text);
			//npcNameText.text = dialogueHolder.npcName;
			inkJSON = dHolder.GetComponent<DialogueHolder>().inkJSONtoPlay;
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

			foreach( char letter in line.ToCharArray() )
			{

				//Checking if player wants to finish text printing
				//if(onSkipPrint)
				//{
				//	dialoguetext.text = line;
				//	break;
				//}

				//Debug.Log(letter);
				dialoguetext.text += letter;
				//Debug.Log(dialoguetext.text);
				//Debug.Log("print and wait");
				yield return new WaitForSeconds(typingSpeed);
			}

			canContinueToNextLine = false;
		}
		public void ExitDialogueMode()
		{
			//Debug.Log("End Conversation");
			dialogueIsPlaying = false;
			dialoguetext.text = "";
			talkBool = false;
			dialogueBox.SetActive(false);
		}

		public void ContinueStory()
		{
			//onSkipPrint = true;
			if(//canContinueToNextLine && 
				currentStory.canContinue )
			{
				//onSkipPrint = false;

				if( displayLineCoroutine != null )
				{
					StopCoroutine(displayLineCoroutine);
				}

				displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
				//DisplayChoices();
				//Debug.Log("can continue story");

				//Handle ink tags
				HandleTags(currentStory.currentTags);
			}
			else
			{
				ExitDialogueMode();
			}

			//onSkipPrint = false;
		}

		private void HandleTags(List<string> currentTags)
		{
			foreach( string tag in currentTags )
			{
				//Split ink tags by :
				string[] splitTag = tag.Split(':');
				if( splitTag.Length != 2 )
				{
					Debug.LogError("ink tag could not be read: " + tag);
				}

				string tagKey = splitTag[0].Trim();
				string tagValue = splitTag[1].Trim();

				switch( tagKey )
				{
					case SPEAKER_TAG:
					//Debug.Log("speaker = " + tagValue);
					npcNameText.text = tagValue;
						break;
					case PORTRAIT_TAG:
					//Debug.Log("portrait = " + tagValue);
					break;
					case LAYOUT_TAG:
					//Debug.Log("layout = " + tagValue);
					layoutAnimator.Play(tagValue);
					break;
					default:
					Debug.LogWarning("Tag read but can't be handlled: " + tag);
					break;
				}

			}
		}

	}
}