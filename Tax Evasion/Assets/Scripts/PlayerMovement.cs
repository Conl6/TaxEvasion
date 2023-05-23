using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    private float moveSpeed = 2f;
    public Vector3 moveDirection;
    private float rotationSpeed = 4f;

    [Header("Ground Settings")]
    public float groundDrag;

    [Header("Refrence")]
    public Transform orientation;

    Rigidbody rb;
    float horizontalInput;
    float verticalInput;    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        rb.drag = groundDrag;
    }
    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void PlayerInput()
    {
        // Retrieve the horizontal and vertical input values from the input system
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate the movement direction based on the orientation and input values
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void RotatePlayer()
    {
        if (moveDirection.magnitude > 0)
        {
            // Calculate the target rotation based on the movement direction and the orientation
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection.normalized, Vector3.up);

            // Smoothly rotate the player towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}