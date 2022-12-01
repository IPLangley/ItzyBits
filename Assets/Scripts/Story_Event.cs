using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Event : Event
{
    [SerializeField]
    PlayerStats stats;
    // Start is called before the first frame update
    void Awake()
    {
        stats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EventStart()
    {
        stats.gameWin();
        base.EventStart();
        Debug.Log("The Story Event Has Started");
    }
}
