using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Dialogue;
using Ink.Runtime;
using UnityEngine.InputSystem;
using Ink.UnityIntegration;

namespace VartraAbyss
{
    public class NotFelixTrigger : MonoBehaviour
    {
        [SerializeField] DialogueSystem dialogueSystem;
        [SerializeField] DialogueHolder dialogueHolder;
        [SerializeField] Dialogue_trigger dialogueTrigger;
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && !dialogueSystem.dialogueIsPlaying)
            {
                dialogueSystem.dHolder = this.gameObject;
                dialogueSystem.EnterDialogueMode(dialogueTrigger.inkJSON);
                //dialogueSystem.PerformTalk();
            }
        }

        private void Awake()
        {
            dialogueSystem.GetComponent<DialogueSystem>();
            dialogueTrigger.GetComponent<Dialogue_trigger>();
        }
    }
}
