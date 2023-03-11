using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour
{
    public GameObject startPos;
    public Canvas timercolss;
    public Text TimerText;
    private bool isPlaying;
    public int appleCount;

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

    private void Awake()
    {
        transform.position = startPos.transform.position;
        appleCount = 0;


    }




    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float curSpeedX = canMove ? walkSpeed * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? walkSpeed * Input.GetAxis("Horizontal") : 0;

        float moveDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Jump
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            Jump();
        else
            moveDirection.y = moveDirectionY;

        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        // Move
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotate
        if (canMove)
        {
            Rotate();
        }
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



    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("startTimer"))
        {
            Application.LoadLevel("MainMenu");
        }
        if (collider.gameObject.CompareTag("apple"))
        {
            appleCount++;
        }

    }

    public int GetApples()
    {
        return appleCount;
    }

   
}