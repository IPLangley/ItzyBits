using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue_Manager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences; // Will load sentences in a FIFO manner.

    // Start is called before the first frame update and initializes the previous line of code.
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Can get rid of this after bringing up nameText. --> Debug.Log("Starting conversation with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear(); // Clears any existing sentences from a previous conversation.

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); // Displays the first sentence of our queue.

    }

    public void DisplayNextSentence() // Is callable from our "Continue" button.
    {
        if (sentences.Count == 0) // Ends the dialogue when there are no longer any sentences to load.
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); // If we have more sentences to say, gets the next sentence in the queue.
        dialogueText.text = sentence; // Updates the User Interface to show that the conversation is progressing.
        //Debug.Log(sentence); Shows text in the console.
    }

    void EndDialogue() // Displays a message to show the user that the conversation has ended.
    {
        Debug.Log("End of conversation.");
    }
}
