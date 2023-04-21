using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeJumpScareScript : MonoBehaviour
{
    public GameObject sound;
    public Transform spawnPos;
    public GameObject smoke;
    public Transform smokePos;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            Instantiate(sound, spawnPos.position, spawnPos.rotation);
            Instantiate(smoke, smokePos.position, smokePos.rotation);
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.1f);
        }
    }


    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
