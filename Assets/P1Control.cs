using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class P1Control : MonoBehaviour
{
    public PinkTrigger pinkTrigger;
    public bool isJumping = false;
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;
    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;




    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");

        if (characterController.isGrounded)
        {
            // If the player was jumping and is now grounded, they have landed
            if (isJumping)
            {
                isJumping = false;
            }

            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;

            if (Input.GetKey(KeyCode.S) && !isJumping)
            {
                moveVelocity.y = jumpSpeed;
                isJumping = true;
            }
        }

        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the trigger
        if (other.gameObject.CompareTag("Blue"))
        {
            //Debug.Log("p Triggered");
            // Add a point
            pinkTrigger.AddPoint();
        }
    }
}

/*var hInput = Input.GetAxis("Horizontal");
var vInput = Input.GetAxis("Vertical");
if (characterController.isGrounded)
{
    moveVelocity = transform.forward * speed * vInput;
    turnVelocity = transform.up * rotationSpeed * hInput;
    if (Input.GetKey(KeyCode.S) && !isJumping)
    {
        moveVelocity.y = jumpSpeed;
        isJumping = true;
    }
}
//Adding gravity
moveVelocity.y += gravity * Time.deltaTime;
characterController.Move(moveVelocity * Time.deltaTime);
transform.Rotate(turnVelocity * Time.deltaTime);
}
void OnCollisionEnter(Collision collision)
{
// If the player lands on the ground, stop jumping
if (collision.gameObject.tag == "Ground") // Replace "Ground" with the tag of your ground object
{
    isJumping = false;
}
}*/

