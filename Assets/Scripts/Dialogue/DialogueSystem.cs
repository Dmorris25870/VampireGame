using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.InputSystem;
using VartraAbyss.Actions;


namespace VartraAbyss.Dialogue
{
	[System.Serializable]
	public class DialogueSystem : MonoBehaviour
	{
		[Header("Dialogue UI")]
		[SerializeField] private GameObject dialogueBox;
		[SerializeField] private TextMeshProUGUI dialoguetext;


        //[SerializeField] private TextAsset m_inkTextFile;
		//[SerializeField] private Story m_currentStory;
		[SerializeField] private Story currentStory;
		//[SerializeField] private List<Dialogue> m_listOfDialogues = new List<Dialogue>();

		private static DialogueSystem instance;
		private bool dialogueIsPlaying;
		public InputActionReference actionRef;
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

        private void Start()
        {
			dialogueIsPlaying = false;
			dialogueBox.SetActive(false);
        }

        private void Update()
        {
			if (!dialogueIsPlaying)
			{
				return;
			}

			if (InputManager.GetInstance().GetSubmitPressed())
			{

			}

			//if (actionRef.action.performed)
   //         {
			//	actionRef.action.IsPressed	
			//}
		}

        public void EnterDialogueMode (TextAsset inkJSON)
		{
			currentStory = new Story(inkJSON.text);
			dialogueIsPlaying = true;
			dialogueBox.SetActive(true);

			if (currentStory.canContinue)
			{
				dialoguetext.text = currentStory.Continue();
			}
			else
			{
				ExitDialogueMode();
			}
		}

		private void ExitDialogueMode()
		{
            dialogueIsPlaying = false;
            dialogueBox.SetActive(false);
			dialoguetext.text = "";
        }
    }
}