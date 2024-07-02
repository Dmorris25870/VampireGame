using UnityEngine;
using VartraAbyss.Dialogue;

public class DialogueHolder : MonoBehaviour
{
	[Header("Visual Cue")]
	[SerializeField] public GameObject visualCue;

	[Header("Ink JSON")]
	[SerializeField] public TextAsset inkJSONtoPlay;

	//private static Dialogue_trigger instance;

	[SerializeField] private DialogueSystem dialogueSystem;

	private bool playerInRange;
	public string npcName;

	private void Awake()
	{
		// if (instance != null)
		// {
		//     Debug.LogWarning("Found more than one Dialogue trigger");
		// }
		//// instance = this;

		//playerInRange = false;
		visualCue.SetActive(false);
	}

	//public static Dialogue_trigger GetInstance()
	//{
	//    return instance;
	//}

	private void Update()
	{
		//CheckPlayerInRange();
		//if (playerInRange && !DialogueSystem.GetInstance().dialogueIsPlaying)
		//{
		//    visualCue.SetActive(true);
		//    if (InputManager.GetInstance().GetPotionPressed())
		//    {
		//        Debug.Log(inkJSON.text);
		//    }

		//    if (DialogueSystem.talkBool)
		//    {

		//        DialogueSystem.GetInstance().EnterDialogueMode(inkJSON);
		//    }

		//}
		//else
		//{
		//    visualCue.SetActive(false);
		//}

		//if (DialogueSystem.talkBool) //&& !DialogueSystem.GetInstance().dialogueIsPlaying)
		//{
		//    inkJSONtoPlay = dialogueSystem.GetComponent<DialogueHolder>().inkJSON;
		//    dialogueSystem.EnterDialogueMode(inkJSONtoPlay);
		//}
	}
	private void OnTriggerEnter(Collider other) //Triggers popup above NPC when Player is in range and dialougue is not already playing
	{
		if( other.gameObject.CompareTag("Player") && !dialogueSystem.dialogueIsPlaying )
		{
			//playerInRange = true;
			visualCue.SetActive(true);

			//Debug.Log("current Ink is: " + inkJSON.text);
			dialogueSystem.dHolder = this.gameObject;
		}


	}

	private void OnTriggerExit(Collider other) //Turns off NPC talk popup off
	{
		//playerInRange = false;
		if( other.gameObject.CompareTag("Player") )
		{
			visualCue.SetActive(false);

			dialogueSystem.dHolder = null;
		}

	}

	//private void CheckPlayerInRange()
	//{
	//    if (playerInRange)
	//    {
	//        visualCue.SetActive(true);
	//        if (InputManager.GetInstance().GetInteractPressed())
	//        {
	//            Debug.Log(inkJSON.text);
	//        }
	//    }
	//    else
	//    {
	//        visualCue.SetActive(false);
	//    }
	//}
}
