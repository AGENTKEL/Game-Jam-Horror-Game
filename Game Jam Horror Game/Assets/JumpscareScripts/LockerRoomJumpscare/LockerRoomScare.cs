using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerRoomScare : MonoBehaviour
{
    public GameObject sound;
    public GameObject sound2;
    public Transform spawnPos;

    public LockerOpenScript doorOpen1;
    public LockerOpenScript doorOpen2;
    public LockerOpenScript doorOpen3;
    public LockerOpenScript doorOpen4;
    public LockerOpenScript doorOpen5;
    public LockerOpenScript doorOpen6;
    public LockerOpenScript doorOpen7;
    public LockerOpenScript doorOpen8;
    public LockerOpenScript doorOpen9;
    public LockerOpenScript doorOpen10;
    public LockerOpenScript doorOpen11;
    public LockerOpenScript doorOpen12;
    public LockerOpenScript doorOpen13;
    public LockerOpenScript doorOpen14;
    public LockerOpenScript doorOpen15;
    public LockerOpenScript doorOpen16;
    public LockerOpenScript doorOpen17;
    public LockerOpenScript doorOpen18;
    public LockerOpenScript doorOpen19;
    public LockerOpenScript doorOpen20;
    public LockerOpenScript doorOpen21;
    public LockerOpenScript doorOpen22;
    public LockerOpenScript doorOpen23;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Instantiate(sound2, spawnPos.position, spawnPos.rotation);
            doorOpen1.OpenDoorAndClose();
            doorOpen2.OpenDoorAndClose();
            doorOpen3.OpenDoorAndClose();
            doorOpen4.OpenDoorAndClose();
            doorOpen5.OpenDoorAndClose();
            doorOpen6.OpenDoorAndClose();
            doorOpen7.OpenDoorAndClose();
            doorOpen8.OpenDoorAndClose();
            doorOpen9.OpenDoorAndClose();
            doorOpen10.OpenDoorAndClose();
            doorOpen11.OpenDoorAndClose();
            doorOpen12.OpenDoorAndClose();
            doorOpen13.OpenDoorAndClose();
            doorOpen14.OpenDoorAndClose();
            doorOpen15.OpenDoorAndClose();
            doorOpen16.OpenDoorAndClose();
            doorOpen17.OpenDoorAndClose();
            doorOpen18.OpenDoorAndClose();
            doorOpen19.OpenDoorAndClose();
            doorOpen20.OpenDoorAndClose();
            doorOpen21.OpenDoorAndClose();
            doorOpen22.OpenDoorAndClose();
            doorOpen23.OpenDoorAndClose();
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.01f);
        }
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    } 
}
