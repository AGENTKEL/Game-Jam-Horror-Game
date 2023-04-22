using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class MonsterSoundManager : MonoBehaviour
{
    public List<AudioClip> runSounds;
    public AudioSource audioSource;
    public int pos;

    public List<AudioClip> stepsSounds;
    public AudioSource audioSource2;
    public int pos2;

    public List<AudioClip> spawnOrKillSound;
    public AudioSource audioSource3;
    public int pos3;

    public void Start()
    {
        InvokeRepeating("PlaySound", Random.Range(5f, 7f), Random.Range(5f, 7f));
    }

    public void PlaySound()
    {
        pos = (int)Mathf.Floor(Random.Range(0, runSounds.Count));
        audioSource.PlayOneShot(runSounds[pos]);
        Debug.Log("Quiet Sound");
    }

    public void PlaySound2()
    {
        pos2 = (int)Mathf.Floor(Random.Range(0, stepsSounds.Count));
        audioSource2.PlayOneShot(stepsSounds[pos2]);
        Debug.Log("Medium Sound");
    }

    public void PlaySound3()
    {
        pos3 = (int)Mathf.Floor(Random.Range(0, spawnOrKillSound.Count));
        audioSource3.PlayOneShot(spawnOrKillSound[pos3]);
        Debug.Log("Loud Sound");
    }
}
