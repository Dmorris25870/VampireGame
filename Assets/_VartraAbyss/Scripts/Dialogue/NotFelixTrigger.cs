using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VartraAbyss.Dialogue;

namespace VartraAbyss
{
    public class NotFelixTrigger : MonoBehaviour
    {
        [SerializeField] DialogueSystem dialogueSystem;
        [SerializeField] DialogueHolder dialogueHolder;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "player")
            {
                dialogueSystem.EnterDialogueMode(dialogueHolder.inkJSONtoPlay);
            }
        }
    }
}
