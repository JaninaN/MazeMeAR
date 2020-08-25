using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOptions : MonoBehaviour {

    public int Door_Number;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject.GetComponent<HoldItems>().useKey(Door_Number))
            {
                //open door
                Vector3 doorSize = GetComponent<Renderer>().bounds.size;
                Vector3 point;
                if(doorSize.x > doorSize.z)
                {
                    point = transform.TransformPoint(new Vector3((doorSize.x / 2f) - (doorSize.z / 2f), 0f, 0f));
                }
                else
                {
                    point = transform.TransformPoint(new Vector3(0f, 0f, (doorSize.z / 2f) - (doorSize.x / 2f)));
                }
                transform.RotateAround(point, new Vector3(0f, 1f, 0f), 90f);
            }
        }
    }
}
