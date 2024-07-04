using UnityEngine;
using VartraAbyss.Dialogue;


public class Dialogue_trigger : MonoBehaviour
{
	//[Header("Visual Cue")]
	//[SerializeField] private GameObject visualCue;

	[Header("Ink JSON")]
	[SerializeField] public TextAsset inkJSON;

	//private static Dialogue_trigger instance;

	[SerializeField] private DialogueSystem dialogueSystem;

	public bool playerInRange;
	//public string npcName = "steve";

	private void Awake()
	{
		// if (instance != null)
		// {
		//     Debug.LogWarning("Found more than one Dialogue trigger");
		// }
		//// instance = this;

		//playerInRange = false;
		//visualCue.SetActive(false);
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

		if( DialogueSystem.talkBool ) //&& !DialogueSystem.GetInstance().dialogueIsPlaying)
		{

			dialogueSystem.EnterDialogueMode(inkJSON);
		}
	}
	private void OnTriggerEnter(Collider other) //Triggers popup above NPC when Player is in range and dialougue is not already playing
	{		
		if( other.gameObject.tag == "NPC") //&& !dialogueSystem.dialogueIsPlaying )
		{
			Debug.Log("TriggerEnter NPC");
			playerInRange = true;
			//visualCue.SetActive(true);
			inkJSON = other.GetComponent<DialogueHolder>().inkJSONtoPlay;
		}
	}



	private void OnTriggerExit(Collider other) //Turns off NPC talk popup off
	{
		Debug.Log("TriggerExit");
		if( other.gameObject.tag == "NPC" )
		{
			playerInRange = false;
		}
			
		//if (other.gameObject.tag == "Player")
		//{
		//    //visualCue.SetActive(false);
		//}

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
