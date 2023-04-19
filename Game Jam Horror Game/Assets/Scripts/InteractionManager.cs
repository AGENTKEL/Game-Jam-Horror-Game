using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    

    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private float rayDistance;
    RaycastHit hit;
    private Ray ray;

    public GameObject handUI;
    public Transform PCAM;

    static public bool KeypadUI;
    public GameObject KeypadDisplay;

    void Awake() 
    {
        
    }

    void Update()
    {
        switch (KeypadUI)
        {
        case false:
            //make sure player can move and update where we raycast
            ray = new Ray (PCAM.position, PCAM.forward);
            KeypadDisplay.SetActive(false);
            disablePlayer();

            if (Physics.Raycast (ray, out hit, rayDistance, collisionMask))
            {
                handUI.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    WhichThingWasInteractedWith();
                }
            }
            else
                handUI.SetActive(false);
            break;
        case true:
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                KeypadUI = false;
                KeypadDisplay.SetActive(false);
                disablePlayer();
            }
            break;
        }
    }

    private void WhichThingWasInteractedWith()
    {
        if (hit.collider.tag == "Keypad" && KeypadUI == false)
            {
                KeypadUI = true;
                KeypadDisplay.SetActive(true);
                disablePlayer();
            }
    }

    private void disablePlayer()
    {
        switch (KeypadUI)
        {
        case true:
            PlayerController.movementEnabled = false;
            Cursor.lockState = CursorLockMode.None;
            break;
        case false:
            PlayerController.movementEnabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            break;
        }
    }
}
