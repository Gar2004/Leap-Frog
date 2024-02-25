using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class P2Control : MonoBehaviour
{
    public BlueTrigger blueTrigger;


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
            if (isJumping)
            {
                isJumping = false;
            }
            moveVelocity = transform.forward * speed * vInput;
            turnVelocity = transform.up * rotationSpeed * hInput;
            if (Input.GetKey(KeyCode.K) && !isJumping)
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
        // Debug.Log("B Triggered");
        if (other.gameObject.CompareTag("Pink"))
        {
            blueTrigger.AddPoint();
        }
        if (other.gameObject.CompareTag("lava"))
        {
            blueTrigger.MinusPoint();
        }
    }
}
