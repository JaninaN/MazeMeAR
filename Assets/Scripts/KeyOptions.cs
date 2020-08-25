using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOptions : MonoBehaviour
{

    public int Key_Number = 0;

    private float rotaSpeed = 2f;
    private bool active = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.RotateAround(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0f, 1f, 0f), rotaSpeed * Time.deltaTime * 100);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<HoldItems>().addKey(Key_Number);
            deactivate();
        }
    }

    public bool isInactive()
    {
        return !active;
    }

    public void deactivate()
    {
        GetComponent<Renderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        active = false;
    }
}
