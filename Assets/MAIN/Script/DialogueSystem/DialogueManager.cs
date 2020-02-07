using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class DialogueManager : GenericSingleton<DialogueManager>
{
    #region VARIABLES
    private Queue<string> sentences; // FIFO collection
    private GameObject dialogueBox;
    private string currentSentence;

    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;

    private GameObject[] players;
    private int triggerIDcount = 0;

    public GameObject[] dialogueTriggers;
    public bool sentenceIsComplete = false;
    #endregion

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox = GameObject.FindGameObjectWithTag("dialogue_box");
        nameText = dialogueBox.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueBox.transform.Find("Sentence").GetComponent<TextMeshProUGUI>();

        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players) {
            player.GetComponent<PlayerInput>().PassivateInput();
        }

        foreach (GameObject trigger in dialogueTriggers) {
            if (trigger.GetComponent<DialogueTrigger>().ID != 1) {
                trigger.SetActive(false);
            }
        }

        dialogueBox.SetActive(false);
    }
    
    public void StartDialogue(Dialogue dialogue) {
        
        foreach (GameObject player in players) {
            player.GetComponent<PlayerInput>().PassivateInput();
        }

        dialogueBox.SetActive(true);

        nameText.text = dialogue.name;
        sentences.Clear();

        // Go through all of the strings in the dialogue string array and queue them
        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        sentenceIsComplete = false;
        string sentence = sentences.Dequeue();
        currentSentence = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue() {
        dialogueBox.SetActive(false);
        sentenceIsComplete = false;

        dialogueTriggers[triggerIDcount].SetActive(false);

        triggerIDcount++;
        if (triggerIDcount < dialogueTriggers.Length) {
            dialogueTriggers[triggerIDcount].SetActive(true);
        }
        
        foreach (GameObject player in players) {
            player.GetComponent<PlayerInput>().ActivateInput();
        }
    }

    public void CompleteCurrentSentence() {
        StopAllCoroutines();
        dialogueText.text = currentSentence;
        sentenceIsComplete = true;
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            if (sentence.Length == dialogueText.text.Length) {
                sentenceIsComplete = true;
            }
            yield return null;
        }
    }
}
