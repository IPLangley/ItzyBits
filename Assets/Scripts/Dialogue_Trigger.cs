using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
    public Dialogue dialogue; // Uses the Dialogue data type we created in the "Dialogue.cs" file.
                              // Creates a dialogue variable that allows us to enter a name and any number of 
                              // sentences in Unity.

    public void TriggerDialogue() // Will feed our created sentences in Unity to our DialougeManager.cs.
    {
        FindObjectOfType<Dialogue_Manager>().StartDialogue(dialogue); // Locates our dialogue manager and tells it what
                                                                     // conversation to start.
    }
}
