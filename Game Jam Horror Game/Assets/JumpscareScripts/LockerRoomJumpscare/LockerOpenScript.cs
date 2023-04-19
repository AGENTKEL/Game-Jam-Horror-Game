using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerOpenScript : MonoBehaviour
{
    public Animator animator;



    public void OpenDoorAndClose()
    {
        animator.SetBool("Is Open", true);
        Invoke("CloseDoor", 4f);
    }

    public void CloseDoor()
    {
        animator.SetBool("Is Open", false);
    }
}
