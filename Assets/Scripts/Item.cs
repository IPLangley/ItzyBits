using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemDesc;
    public float cost;
    public float change;

    public PlayerStats.stats tochange;
    PlayerStats player;


    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void useItem()
    {
        player.changeStat(tochange, change);
    }
}
