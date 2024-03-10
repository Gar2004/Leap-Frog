using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class P1Control : MonoBehaviour
{
    //[SerializeField] Transform target;
    public Pink_PlayerManager player;
    public bool isJumping = false;
    public float speed = 3;
    public float rotationSpeed = 90;
    public float gravity = -20f;
    public float jumpSpeed = 15;

    public float pushForce = 3.0f; //Amount of force to apply

    private ControllerColliderHit contact;
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
            player.AddPoint();
        }

        if (other.gameObject.CompareTag("lava"))
        {
            player.MinusPoint();
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * pushForce;
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

