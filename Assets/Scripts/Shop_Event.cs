using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Event : Event
{
    // Start is called before the first frame update
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
        Debug.Log("The Shop Event Has Started");
        player.AddMoney(-5);
    }

}
