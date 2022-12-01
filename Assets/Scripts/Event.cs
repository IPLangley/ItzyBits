using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour
{
    public string eventName;
    public string eventDescription;
    SpriteRenderer sprite;
    GameObject tempName;
    [SerializeField]
    Event_Handler eventHandler;


    bool eventOver = false;
    [SerializeField]
    Vector3 pos;

    // Start is called before the first frame update
    void OnEnable()
    {
        eventHandler = GetComponentInParent<Event_Handler>();
        this.GetComponentInChildren<Button>().transform.position = eventHandler.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventOver)
        {
            Invoke("EventEnd",2f);
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
