using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    public Transform[] wayPoints;
    public float speed;
    public int currentWayPoint;
    public bool doPatrol = true;
    public Vector3 target;
    public Vector3 moveDirection;
    public Vector3 velocity;

    private Animator anim;
    private int walkHash = Animator.StringToHash("walking");
    private CharacterController controller;
    private string animPatrol = "walking";

    void start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
		if(doPatrol && currentWayPoint < wayPoints.Length)
        {
            controller = GetComponent<CharacterController>();
            target = wayPoints[currentWayPoint].position;
            moveDirection = target - transform.position;
            //velocity = GetComponent<Rigidbody>().velocity;
            //transform.Translate(Vector3.Normalize(moveDirection) * Time.deltaTime * speed);
            controller.Move(Vector3.Normalize(moveDirection) * Time.deltaTime * speed);
            if (moveDirection.magnitude < 50)
            {
                currentWayPoint++;
            }
        }
        else if (doPatrol)
        {
            currentWayPoint = 0;
        }

        //GetComponent<Rigidbody>().velocity = velocity;
        transform.LookAt(target);
	}


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            hit.gameObject.GetComponent<Player>().hit();
        }
    }
}
