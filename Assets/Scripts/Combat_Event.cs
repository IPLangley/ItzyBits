using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Event : Event
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
        Debug.Log("The Combat Event Has Started");
        player.Damage(5);
        player.AddMoney(15);
    }

}
