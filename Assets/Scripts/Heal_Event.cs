using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Event : Event
{

    float healValue = 5;
    PlayerStats player;
    void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void EventStart()
    {
        base.EventStart();
        Debug.Log("The Heal Event Has Started");
        player.Heal(healValue);

    }
}
