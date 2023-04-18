using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    RaycastHit hit;

    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private float rayDistance;
    private Ray ray;

    public GameObject handUI;
    public Transform PCAM;

    void Awake() 
    {
        ray = new Ray (PCAM.position, PCAM.forward);
    }

    void Update()
    {
        Debug.DrawRay(PCAM.position, PCAM.forward * rayDistance, Color.red);
        if (Physics.Raycast (ray, out hit, rayDistance, collisionMask))
        {
            handUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                print("got it");
            }
        }
        else
            handUI.SetActive(false);
    }
}
