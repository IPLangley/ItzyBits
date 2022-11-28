using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat_Event : Event
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
        Debug.Log("The Combat Event Has Started");
        player.Damage(5);
        player.AddMoney(15);
        SceneManager.LoadScene("Combat");
        this.gameObject.SetActive(false);
    }

}
