using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_Event : Event
{

    float healValue = 5;
    Player_Controller player;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player_Controller>();
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
