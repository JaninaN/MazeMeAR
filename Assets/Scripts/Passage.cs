using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour {

    public Passage targetPassage;
    public GameObject Player_Spawn;

    private GameObject targetRoom;
    private GameObject thisRoom;

	// Use this for initialization
	void Start () {
        //search in Parents for the Room GameObject
        thisRoom = gameObject;
        while (thisRoom.tag != "Room")
        {
            thisRoom = thisRoom.transform.parent.gameObject;
        }

        targetRoom = targetPassage.gameObject;
        while(targetRoom.tag != "Room")
        {
            targetRoom = targetRoom.transform.parent.gameObject;
        }
        
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider>().enabled = false;
            targetPassage.gameObject.GetComponent<Collider>().enabled = true;
            //switch Position of rooms
            Vector3 activePos = transform.localPosition;
            Vector3 standbyPos = targetRoom.transform.localPosition;
            thisRoom.transform.localPosition = standbyPos;
            targetRoom.transform.localPosition = activePos;

            //set new Position of player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = targetPassage.getPlayerSpawn();
            player.GetComponent<Player>().setSpawn(targetPassage.getPlayerSpawn());
        }
    }

    public Vector3 getPlayerSpawn()
    {
        return Player_Spawn.transform.position;
    }
}
