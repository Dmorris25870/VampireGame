using Ink.Runtime;
using System.Collections;
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

		private void OnEnable()
		{
			letsTalk.action.performed += PerformTalk;
		}

		private void OnDisable()
		{
			letsTalk.action.performed -= PerformTalk;
			Debug.Log("Enable talk");
		}

		private void Start()
		{
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
			//InitialiseChoices();
		}

		public void PerformTalk(InputAction.CallbackContext context)
		{
			if( dialogue_Trigger.playerInRange )
			{
				EnterDialogueMode(dialogue_Trigger.inkJSON);
			}
			else
			{
				Debug.Log("No talky");
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
			npcNameText.text = dialogueHolder.npcName;
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
				Debug.Log(letter);
				dialoguetext.text += letter;
				Debug.Log(dialoguetext.text);
				Debug.Log("print and wait");
				yield return new WaitForSeconds(typingSpeed);
			}

			canContinueToNextLine = false;
		}
		public void ExitDialogueMode()
		{
			Debug.Log("End Conversation");
			dialogueIsPlaying = false;
			dialoguetext.text = "";
			talkBool = false;
			dialogueBox.SetActive(false);
		}

		public void ContinueStory()
		{
			if(//canContinueToNextLine && 
				currentStory.canContinue )
			{


				if( displayLineCoroutine != null )
				{
					StopCoroutine(displayLineCoroutine);
				}

				displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
				//DisplayChoices();
				Debug.Log("can continue story");
			}
			else
			{
				ExitDialogueMode();
			}
		}

	}
}