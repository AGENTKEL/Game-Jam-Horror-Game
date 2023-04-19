using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerHeight;
    [SerializeField] private float crouchHeight;
    private CharacterController controller;
    public Transform PlayerCam;
    [SerializeField] private Vector3 playerVelocity = Vector3.zero;
    [SerializeField] private Transform groundcheck;
    static public bool movementEnabled = true;

    public float playerSpeed = 2.0f;
    public float playerSprintSpeed = 4.0f;
    public float crouchSpeed = 1f;
    private float gravityValue = 9.81f;

    public float mouseSensitivity = 1f;
    private float xRotation = 0f;
    private bool isSprinting = false;
    [SerializeField] private float t = 3f;

    [SerializeField] private Vector3 move;
    private bool isMoving;
    [SerializeField] private bool Grounded;

    public LayerMask groundMask;

    [Header("Headbob stuff")]
    [SerializeField] private float walkBobSpeed = 14f;
    [SerializeField] private float walkBobAmount = 0.05f;
    [SerializeField] private float sprintBobSpeed = 18f;
    [SerializeField] private float sprintBobAmount = 0.1f;
    [SerializeField] private float crouchBobSpeed = 8f;
    [SerializeField] private float crouchBobAmount = 0.025f;
    private float defaultYPos;
    private float crouchedYPos;
    private float timer;

    private Vector3 newmove;
    private Vector3 finalmove;

    private float getupYPos;
    public float getupmodifier;

    private bool isCrouching = false;
    private float floorheight;

    static public bool HBenabled = true;

    


    //CROUCHING IS STILL JITTERY BUT I AM SO DONE WORKING ON THIS FOR NOW ITS BEEN DAYS


    void Awake() 
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        defaultYPos = PlayerCam.transform.localPosition.y;
        crouchedYPos = (0.35f);
    }

    void Update()
    {
        checkIfGrounded();
        if (movementEnabled)
        {
            HandleMovement();
            HandleHeadBob();
            HandleCamera();
            HandleCrouching();
        }
    }

    private void HandleMovement()
    {
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        if (move == Vector3.zero)
            isMoving = false;
        else 
            isMoving = true;
        
        switch(Grounded)
        {
            case true:
                playerVelocity.y = 0f;
                break;
            case false:
                playerVelocity.y -= gravityValue * Time.deltaTime;
                break;
        }

        newmove = (Vector3.ClampMagnitude(move, 1.0f) * Time.deltaTime * (isCrouching ? crouchSpeed : isSprinting ? playerSprintSpeed : playerSpeed));

        finalmove = new Vector3(newmove.x, playerVelocity.y * Time.deltaTime, newmove.z);

        controller.Move(finalmove);
    }

    private void HandleCrouching()
    {
        Vector3 crouchCamPos = new Vector3(0, 0.35f, 0); //i just have to figure these two out after i get the height right
        Vector3 normalCamPos = new Vector3(0f, 0.75f, 0f);
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            floorheight = (transform.position.y - (controller.height / 2));
        }

        if (Input.GetKey(KeyCode.LeftControl))
			{
                PlayerCam.transform.localPosition = Vector3.Lerp(PlayerCam.transform.localPosition, crouchCamPos, t * Time.deltaTime);
                controller.height = Mathf.Lerp(controller.height, crouchHeight, t * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, (floorheight + (crouchHeight / 2)), transform.position.z), ((t * 2) * Time.deltaTime));
            }
		else if (controller.height < playerHeight && !Physics.Raycast(PlayerCam.transform.position, Vector3.up, (playerHeight / 2)))
			{
                PlayerCam.transform.localPosition = Vector3.Lerp(PlayerCam.transform.localPosition, normalCamPos, t * Time.deltaTime);
                controller.height = Mathf.Lerp(controller.height, playerHeight, t * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, (floorheight + (playerHeight / 2)), transform.position.z), ((t * 2) * Time.deltaTime));
            }
        if (controller.height > (playerHeight - 0.05f))
            controller.height = playerHeight;

        isCrouching = (controller.height < 1.5);
    }

    private void HandleCamera()
    {
        //camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        PlayerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void checkIfGrounded()
    {
        groundcheck.localPosition = new Vector3(0, -(controller.height / 2), 0);
        Grounded = Physics.CheckSphere(groundcheck.position, 0.2f, groundMask);
    }

    private void HandleHeadBob()
    {
        if (HBenabled)
        {
            if(isMoving == true)
            {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : isSprinting ? sprintBobSpeed : walkBobSpeed);
            PlayerCam.transform.localPosition = new Vector3(
                PlayerCam.transform.localPosition.x,
                Mathf.Lerp(PlayerCam.transform.localPosition.y, (isCrouching ? crouchedYPos : defaultYPos) + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : isSprinting ? sprintBobAmount : walkBobAmount), (t * 2) * Time.deltaTime),
                PlayerCam.transform.localPosition.z);
            }
        }
        
    }
}
