using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : GenericSingleton<DialogueManager>
{
    private Queue<string> sentences; // FIFO collection
    private GameObject dialogueBox;
    private string currentSentence;

    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
 
    public bool sentenceIsComplete = false;

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox = GameObject.FindGameObjectWithTag("dialogue_box");
        nameText = dialogueBox.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        dialogueText = dialogueBox.transform.Find("Sentence").GetComponent<TextMeshProUGUI>();

        dialogueBox.SetActive(false);
    }
    
    public void StartDialogue(Dialogue dialogue) {

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
