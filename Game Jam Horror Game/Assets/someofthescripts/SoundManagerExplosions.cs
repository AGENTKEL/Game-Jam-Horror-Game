using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerExplosions : MonoBehaviour
{
    public List<AudioClip> explosionSounds;
    public AudioSource audioSource;
    public int pos;

    public List<AudioClip> explosionSound;
    public AudioSource audioSource2;
    public int pos2;


    void OnEnable()
    {
        Invoke("PlaySound2", 1f);
        InvokeRepeating("PlaySound", Random.Range(3f, 5f), Random.Range(3f, 5f));
    }

    public void PlaySound()
    {
        pos = (int)Mathf.Floor(Random.Range(0, explosionSounds.Count));
        audioSource.PlayOneShot(explosionSounds[pos]);
        Debug.Log("Explosion Sound");
    }

    public void PlaySound2()
    {
        pos2 = (int)Mathf.Floor(Random.Range(0, explosionSound.Count));
        audioSource2.PlayOneShot(explosionSound[pos2]);
        Debug.Log("Explosion Sound");
    }


}
