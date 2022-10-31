using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public string eventName;
    public string eventDescription;
    SpriteRenderer sprite;
    GameObject tempName;
    [SerializeField]
    Event_Handler eventHandler;


    bool eventOver = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        eventHandler = GetComponentInParent<Event_Handler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventOver)
        {
            EventEnd();
        }
    }

    public virtual void EventStart()
    {
        EventEnd();
    }

    public virtual void EventEnd()
    {
        eventHandler.nextEvent();
    }


}
