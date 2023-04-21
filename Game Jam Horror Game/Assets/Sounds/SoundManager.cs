using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> QuietSounds;
    public AudioSource audioSource;
    public int pos;

    public List<AudioClip> MediumSounds;
    public AudioSource audioSource2;
    public int pos2;

    public List<AudioClip> LoudSounds;
    public AudioSource audioSource3;
    public int pos3;

    public void Start()
    {
        Invoke("PlaySound", 5f);
        InvokeRepeating("PlaySound", Random.Range(12f, 25f), Random.Range(12f, 25f));
    }

    public void PlaySound()
    {
        pos = (int)Mathf.Floor(Random.Range(0, QuietSounds.Count));
        audioSource.PlayOneShot(QuietSounds[pos]);
        Debug.Log("Quiet Sound");
    }

    public void PlaySound2()
    {
        pos2 = (int)Mathf.Floor(Random.Range(0, MediumSounds.Count));
        audioSource2.PlayOneShot(MediumSounds[pos2]);
        Debug.Log("Medium Sound");
    }

    public void PlaySound3()
    {
        pos3 = (int)Mathf.Floor(Random.Range(0, LoudSounds.Count));
        audioSource3.PlayOneShot(LoudSounds[pos3]);
        Debug.Log("Loud Sound");
    }
}
