using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    

    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private float rayDistance;
    public RaycastHit hit;
    private Ray ray;

    public GameObject Key1;
    public GameObject Key2;

    public GameObject handUI;
    public Transform PCAM;

    static public bool DoorInteracted;
    static public bool AudioLogInteracted;

    static public bool KeypadUI;
    public GameObject KeypadDisplay;

    static public GameObject interactedObject;

    static public bool KeyGet1;
    static public bool KeyGet2;

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
                    interactedObject = hit.transform.gameObject;
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
        else if (hit.collider.tag == "Door")
            DoorInteracted = true;
        else if (interactedObject == Key1)
        {
            KeyGet1 = true;
            Destroy(Key1);
        }
        else if (interactedObject == Key2)
        {
            KeyGet2 = true;
            Destroy(Key2);
        }
        else if (hit.collider.tag == "AudioLog")
            AudioLogInteracted = true;
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
