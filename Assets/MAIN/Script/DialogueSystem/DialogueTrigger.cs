using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private DialogueManager dialogueManager;
    private bool dialogueStarted = false;


    private void Awake() {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void Update() {
        if (!dialogueStarted) {
            StartCoroutine(DialogueDelay());
            dialogueStarted = true;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            if (dialogueManager.sentenceIsComplete) {
                dialogueManager.DisplayNextSentence();
            } else {
                dialogueManager.CompleteCurrentSentence();
            }
        }
    }

    IEnumerator DialogueDelay() {
        yield return new WaitForSeconds(3);
        dialogueManager.StartDialogue(dialogue);
    }
}
