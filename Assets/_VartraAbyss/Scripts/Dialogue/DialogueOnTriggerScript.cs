using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Dialogue;
using Ink.Runtime;
using UnityEngine.InputSystem;


namespace VartraAbyss
{
    public class DialogueOnTriggerScript : MonoBehaviour
    {
        [Header("Dialogue System in scene")]
        [SerializeField] DialogueSystem dialogueSystem;
        //[SerializeField] DialogueHolder thisPrefab;
        [Header("PlayerPrefab")]
        [SerializeField] Dialogue_trigger dialogueTrigger;


        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !dialogueSystem.dialogueIsPlaying)
            {
                dialogueSystem.dHolder = this.gameObject;

                StartCoroutine(TalkAndWait());
               
            }
        }

        private void OnTriggerExit(Collider other)
        {
            StopAllCoroutines();
        }

        private void Awake()
        {
            dialogueSystem.GetComponent<DialogueSystem>();
            dialogueTrigger.GetComponent<Dialogue_trigger>();
        }

        IEnumerator TalkAndWait()
        {

            yield return new WaitForSeconds(1);

            dialogueSystem.EnterDialogueMode(dialogueTrigger.inkJSON);
        }
    }
}
