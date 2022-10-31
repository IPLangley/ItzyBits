using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Event : Event
{
    // Start is called before the first frame update
    Player_Controller player;
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
        Debug.Log("The Shop Event Has Started");
        player.AddMoney(-5);
    }

}
