using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLogManager : MonoBehaviour
{
    [Header("AudioLog GameObjects")]
    public GameObject AL1;
    public GameObject AL2;
    public GameObject AL3;
    public GameObject AL4;
    public GameObject AL5;
    public GameObject AL6;

    [Header("Audio Clips")]
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;
    public AudioClip audio6;

    private GameObject obj;
    private AudioSource audioPlayer;

    void Awake()
    {
        audioPlayer = gameObject.GetComponent<AudioSource>();
    }
    
     void Update()
     {
        //just dont look pls
         if (InteractionManager.AudioLogInteracted)
         {
            obj = InteractionManager.interactedObject;
            Destroy(obj);

            if (obj == AL1)
                audioPlayer.clip = audio1;
            else if (obj == AL2)
                audioPlayer.clip = audio2;
            else if (obj == AL3)
                audioPlayer.clip = audio3;
            else if (obj == AL4)
                audioPlayer.clip = audio4;
            else if (obj == AL5)
                audioPlayer.clip = audio5;
            else if (obj == AL6)
                audioPlayer.clip = audio6;

            audioPlayer.Play();
            InteractionManager.AudioLogInteracted = false;
         }
     }
}
