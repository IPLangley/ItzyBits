using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Event : Event
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EventStart()
    {
        base.EventStart();
        Debug.Log("The Story Event Has Started");

    }
}