using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;

        // refresh moving buttons on Canvas
        GameObject player = transform.gameObject;
        GameObject up = GameObject.Find("Button_up");
        GameObject down = GameObject.Find("Button_down");
        GameObject left = GameObject.Find("Button_left");
        GameObject right = GameObject.Find("Button_right");

        up.GetComponent<EventTrigger>().triggers.Clear();
        down.GetComponent<EventTrigger>().triggers.Clear();
        left.GetComponent<EventTrigger>().triggers.Clear();
        right.GetComponent<EventTrigger>().triggers.Clear();

        EventTrigger.Entry entryStop = new EventTrigger.Entry();
        entryStop.eventID = EventTriggerType.PointerUp;
        entryStop.callback.AddListener((eventData) => { player.GetComponent<InputEventHandler>().stopMoving(); });
        up.GetComponent<EventTrigger>().triggers.Add(entryStop);
        down.GetComponent<EventTrigger>().triggers.Add(entryStop);
        left.GetComponent<EventTrigger>().triggers.Add(entryStop);
        right.GetComponent<EventTrigger>().triggers.Add(entryStop);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerDown;
        entryUp.callback.AddListener((eventData) => { player.GetComponent<InputEventHandler>().moveUp(); });
        up.GetComponent<EventTrigger>().triggers.Add(entryUp);

        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((eventData) => { player.GetComponent<InputEventHandler>().moveDown(); });
        down.GetComponent<EventTrigger>().triggers.Add(entryDown);

        EventTrigger.Entry entryLeft = new EventTrigger.Entry();
        entryLeft.eventID = EventTriggerType.PointerDown;
        entryLeft.callback.AddListener((eventData) => { player.GetComponent<InputEventHandler>().moveLeft(); });
        left.GetComponent<EventTrigger>().triggers.Add(entryLeft);

        EventTrigger.Entry entryRight = new EventTrigger.Entry();
        entryRight.eventID = EventTriggerType.PointerDown;
        entryRight.callback.AddListener((eventData) => { player.GetComponent<InputEventHandler>().moveRight(); });
        right.GetComponent<EventTrigger>().triggers.Add(entryRight);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void hit()
    {
        transform.position = startPos;
    }

    public void setSpawn(Vector3 spawn)
    {
        startPos = spawn;
    }
}
