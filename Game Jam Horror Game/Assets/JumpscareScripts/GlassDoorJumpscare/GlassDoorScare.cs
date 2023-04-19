using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorScare : MonoBehaviour
{
    public GameObject sound;
    public Transform spawnPos;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.01f);
        }
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
