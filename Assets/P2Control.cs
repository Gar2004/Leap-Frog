using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class P2Control : MonoBehaviour
{
    public Blue_PlayerManager playerManager;



    // public bool isJumping = false;
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
        var hInput = Input.GetAxis("HorizontalP2");
        var vInput = Input.GetAxis("VerticalP2");
        // if (Input.GetKey(KeyCode.L))
        // {
        //     hInput = Input.GetAxis("Horizontal");
        // }
        // else if (Input.GetKey(KeyCode.J))
        // {
        //     hInput = Input.GetAxis("Horizontal") * -1;
        // }
        // if (Input.GetKey(KeyCode.I))
        // {
        //     vInput = Input.GetAxis("Vertical");
        // }

        if (Input.GetKey(KeyCode.I))
        {
            vInput = 1;
        }
        if (Input.GetKey(KeyCode.L))
        {
            hInput = 1;
        }
        if (Input.GetKey(KeyCode.J))
        {
            hInput = -1;
        }

        if (characterController.isGrounded)
        {
            /*if (isJumping)
            {
                isJumping = false;
            }*/
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if (Input.GetKey(KeyCode.K))
            {
                moveVelocity.y = jumpSpeed;
                // isJumping = true;
            }
        }
        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("B Triggered");
        if (other.transform.tag == "Coin")
        {
            playerManager.AddPoint();
            Debug.Log("Point");
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("lava"))
        {
            playerManager.MinusPoint();
            Destroy(other.gameObject);
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
