using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventHandler : MonoBehaviour {

    Animator anim;
    int speedHash = Animator.StringToHash("Speed");
    int directionHash = Animator.StringToHash("Direction");
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 1.0f;
    private Vector3 rightVec = new Vector3(0, 90, 0);
    private Vector3 leftVec = new Vector3(0, -90, 0);
    private Vector3 upVec = new Vector3(0, 0, 0);
    private Vector3 downVec = new Vector3(0, 180, 0);
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void moveCharacter()
    {
        //if (controller.isGrounded)
        //{
            moveDirection = new Vector3(0, -gravity, 1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= moveSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        //}
        
        anim.SetFloat(speedHash, 1.0f);
    }

	public void moveUp()
    {
        if (transform.eulerAngles != upVec)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        moveCharacter();
    }

    public void moveRight()
    {
        if (transform.eulerAngles != rightVec)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        moveCharacter();
    }

    public void moveDown()
    {
        if (transform.eulerAngles != downVec)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        moveCharacter();
    }

    public void moveLeft()
    {
        if (transform.eulerAngles != leftVec)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        moveCharacter();
    }

    public void stopMoving()
    {
        moveDirection = Vector3.zero;
        anim.SetFloat(speedHash, 0.0f);
    }
}
