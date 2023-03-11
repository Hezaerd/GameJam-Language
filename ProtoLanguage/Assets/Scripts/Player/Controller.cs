using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public float walkSpeed = 6f;
    public float jumpSpeed = 8f;

    public float gravity = 20f;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public Camera playerCamera;

    [HideInInspector]
    private bool canMove = true;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    private void Start()
    {
        // Get components
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;

        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Apply Gravity
        Gravity();

        // Jump
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            Jump();
        else
            moveDirection.y = moveDirectionY;

        // Move
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotate
        if (canMove)
        {
            Rotate();
        }
    }

    private void Gravity()
    {
        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;
    }

    private void Jump()
    {
        moveDirection.y = jumpSpeed;
    }

    private void Rotate()
    {
        rotationX += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);

        playerCamera.transform.localRotation = Quaternion.Euler(-rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }
}