using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VartraAbyss.Dialogue;


public class Dialogue_trigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private static Dialogue_trigger instance;

    private bool playerInRange;
    public string npcName = "steve";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue trigger");
        }
        instance = this;

        playerInRange = false;
        visualCue.SetActive(false);
    }

    public static Dialogue_trigger GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        //CheckPlayerInRange();
        if (playerInRange && !DialogueSystem.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            //if (InputManager.GetInstance().GetPotionPressed())
            //{
            //    Debug.Log(inkJSON.text);
            //}

            if (DialogueSystem.talkBool)
            {
             
                DialogueSystem.GetInstance().EnterDialogueMode(inkJSON);
            }

        }
        else
        {
            visualCue.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInRange = false;
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
