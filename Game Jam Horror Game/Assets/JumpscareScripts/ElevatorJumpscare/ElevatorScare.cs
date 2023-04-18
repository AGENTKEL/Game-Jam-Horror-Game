using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScare : MonoBehaviour
{
    public GameObject sound;
    public Transform spawnPos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Debug.Log("Jumpscare Played");
            DestroyEvent();
        }
    }

    private void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
