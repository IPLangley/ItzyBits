using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Will display it in the Inspector for Unity so we can edit it.

public class Dialogue // Will be used as an object that we can pass into the DialogueManager whenever we 
                      // want to start a new dialogue. This class will host all the necessary information about
                      // a single dialogue.
{
    public string name; // Name of the NPC will we be talking to.

    [TextArea(3, 10)]  // Expands the box, created in DialougeTrigger.cs, where we type in the sentences for our dialouge.
    public string[] sentences; // Creates an array for the sentences we will load into our queue.
}
