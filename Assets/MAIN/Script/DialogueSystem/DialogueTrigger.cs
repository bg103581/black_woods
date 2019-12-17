using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    #region VARIABLES
    public int ID;
    public Dialogue dialogue;
    public GameObject trigger;
    
    private DialogueManager dialogueManager;
    private bool dialogueStarted = false;
    #endregion

    private void Awake() {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Update() {
        
        switch (ID) {
            case 1:
                if (!dialogueStarted) {
                    StartCoroutine(DialogueDelay());
                    dialogueStarted = true;
                }
                break;

            default:
                if (trigger.GetComponent<TriggerObject>().isTriggered) {
                    if (!dialogueStarted) {
                        dialogueManager.StartDialogue(dialogue);
                        dialogueStarted = true;
                    }
                }
                break;
        }

        if (dialogueStarted) {
            CheckIfSentenceIsComplete();
        }
        
    }

    private void CheckIfSentenceIsComplete() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (dialogueManager.sentenceIsComplete) {
                dialogueManager.DisplayNextSentence();
            } else {
                dialogueManager.CompleteCurrentSentence();
            }
        }
    }

    IEnumerator DialogueDelay() {
        yield return new WaitForSeconds(0.5f);
        dialogueManager.StartDialogue(dialogue);
    }
}
