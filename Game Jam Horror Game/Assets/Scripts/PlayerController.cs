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
    private float gravityValue = -9.81f;
    public float mouseSensitivity = 1f;
    private float xRotation = 0f;

    [Header("Crouching stuff")]
    [SerializeField] private float crouchSpeed = 1f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float standingHeight = 2f;
    [SerializeField] private float timeToCrouch = 0.25f;
    [SerializeField] private Vector3 crouchingCenter = new Vector3(0, 0.5f, 0);
    [SerializeField] private Vector3 standingCenter = new Vector3(0, 0, 0);
    private bool isCrouching = false;
    private bool duringCrouchAnimation;

    private bool isSprinting = false;

    private float defaultYPos = 0f;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        defaultYPos = PlayerCam.transform.localPosition.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            HandleCrouch();


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
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        PlayerCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        
    }

    private void HandleCrouch()
    {
        if(!duringCrouchAnimation)
            StartCoroutine(CrouchStand());
    }

    private IEnumerator CrouchStand()
    {
        if(isCrouching && Physics.Raycast(PlayerCam.transform.position, Vector3.up, 1f))
            yield break;

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = controller.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = controller.center;

        while(timeElapsed < timeToCrouch)
        {
            Vector3 Crouchposition = new Vector3(transform.position.x, 0.08f, transform.position.z); //0.8 will have to change if the height changes (probably)

            controller.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
            controller.center = Vector3.Slerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
            if (!isCrouching)
                transform.position = Vector3.Slerp(transform.position, Crouchposition, 4 * timeElapsed/timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        controller.height = targetHeight;
        controller.center = targetCenter;

        isCrouching = !isCrouching;

        duringCrouchAnimation = false;
    }
}

