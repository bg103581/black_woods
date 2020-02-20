using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManager>();
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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Submit")) {
            if ((SceneManager.GetActiveScene().buildIndex != 2) && (SceneManager.GetActiveScene().buildIndex != 4) && (SceneManager.GetActiveScene().buildIndex != 5)) {
                if (dialogueManager.sentenceIsComplete) {
                    dialogueManager.DisplayNextSentence();
                } else {
                    dialogueManager.CompleteCurrentSentence();
                }
            } else {
                if (dialogueManager.sentenceIsComplete) {
                    dialogueManager.DisplayNextSentence();
                }
            }
        }
    }

    IEnumerator DialogueDelay() {
        yield return new WaitForSeconds(0.5f);
        dialogueManager.StartDialogue(dialogue);
    }
}
