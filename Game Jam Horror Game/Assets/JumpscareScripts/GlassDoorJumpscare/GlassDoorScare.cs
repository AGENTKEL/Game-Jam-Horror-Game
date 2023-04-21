using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoorScare : MonoBehaviour
{
    public GameObject sound;
    public Transform spawnPos;
    public MonsterScriptedAi monster;

    public void Start()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Test"))
        {
            monster.gameObject.SetActive(true);
            Debug.Log("Jumpscare Played");
            Invoke("DestroyEvent", 0.3f);
        }
    }


    public void DestroyEvent()
    {
        Instantiate(sound, spawnPos.position, spawnPos.rotation);
        Destroy(gameObject);
    }
}
