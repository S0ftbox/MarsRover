using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    float moveSpeed = 2;
    float gravity = 3;

    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveDirection.y -= gravity;
    }
    
    void Update()
    {
        Debug.Log(controller.isGrounded);
        /*if (controller.isGrounded)
        {*/
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            moveDirection = new Vector3(moveX, 0, moveZ);
            moveDirection *= moveSpeed;

            controller.Move(moveDirection);
        //}
        moveDirection.y -= gravity;
    }
}
