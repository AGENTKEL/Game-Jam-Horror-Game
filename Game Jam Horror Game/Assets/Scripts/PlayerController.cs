using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Transform PlayerCam;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float playerSprintSpeed = 4.0f;
    public float crouchSpeed = 1f;
    private float gravityValue = -9.81f;
    public float mouseSensitivity = 1f;
    private float xRotation = 0f;
    private bool isCrouching = false;
    private bool isSprinting = false;
    private float defaultYPos = 0f;
    [SerializeField] private float t = 3f;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        defaultYPos = PlayerCam.transform.localPosition.y;
    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;

        //if (groundedPlayer && playerVelocity.y < 0)
          //  playerVelocity.y = 0f;
        
        isSprinting = Input.GetKey(KeyCode.LeftShift);    
        //get input
        Vector3 move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        //move
        controller.Move(move * Time.deltaTime * (isCrouching ? crouchSpeed : isSprinting ? playerSprintSpeed : playerSpeed));

        //gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        

        //camera
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        PlayerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        //re-purposed code from another project aka crouching:
            Vector3 positionZero = new Vector3(0, 0.5f, 0);
            Vector3 normalCamPos = new Vector3(0f, 1f, 0f);
            if (Input.GetKey(KeyCode.LeftControl))
			{
                PlayerCam.transform.localPosition = Vector3.Slerp(PlayerCam.transform.localPosition, positionZero, t * Time.deltaTime);
                controller.height = Mathf.Lerp(controller.height, 1.5f, t * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0.83f, transform.position.z), t * Time.deltaTime);
                isCrouching = true;
            }
			else if (controller.height != 2.8 && !Physics.Raycast(PlayerCam.transform.position, Vector3.up, 1.4f))
			{
                PlayerCam.transform.localPosition = Vector3.Slerp(PlayerCam.transform.localPosition, normalCamPos, t * Time.deltaTime);
                controller.height = Mathf.Lerp(controller.height, 2.8f, t * Time.deltaTime);
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 1.48f, transform.position.z), (t * 2) * Time.deltaTime); //a little janky but im done working on this for today hahaha
                isCrouching = false;
            }
    }
}
