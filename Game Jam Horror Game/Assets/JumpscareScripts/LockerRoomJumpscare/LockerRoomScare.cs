using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockerRoomScare : MonoBehaviour
{
    public GameObject sound;
    public GameObject sound2;
    public Transform spawnPos;

    LockerOpenScript doorOpen;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Instantiate(sound2, spawnPos.position, spawnPos.rotation);
            doorOpen.OpenDoorAndClose();
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.01f);
        }
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    } 
}
