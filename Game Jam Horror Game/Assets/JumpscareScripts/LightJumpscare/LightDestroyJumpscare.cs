using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightDestroyJumpscare : MonoBehaviour
{

    public GameObject sound;
    public Transform spawnPos;
    public GameObject lightDestroy;
    public GameObject sparks;
    public Transform sparksPos;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Instantiate(sparks, sparksPos.position, sparksPos.rotation);
            lightDestroy.SetActive(false);
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.1f);
        }
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
