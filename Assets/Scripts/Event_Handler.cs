using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Handler : MonoBehaviour
{

    public List<Event> possibleEvents = new List<Event>();
    public Event currentEvent;
    // Start is called before the first frame update

    private void Start()
    {
        generateEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generateEvent()
    {
        int index = Random.Range(0, possibleEvents.Count);
        currentEvent = Instantiate(possibleEvents[index], transform.position, Quaternion.identity, transform);
        currentEvent.transform.localScale = new Vector3(1,1,1);
        currentEvent.gameObject.SetActive(true);
    }

    public void nextEvent()
    {
        currentEvent.gameObject.SetActive(false);
        generateEvent();
    }
}
