using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MMOptions : MonoBehaviour
{

    static public float mouseSensitivity;
    static public bool headBobEnabled;

    public AudioMixer mixer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        mouseSensitivity = 180f;
        headBobEnabled = true;
    }

    public void AudioChange(System.Single vol)
    {
        mixer.SetFloat ("SoundVol", Mathf.Log10 (vol) * 20);
    }

    public void MouseChange(System.Single sens)
    {
        mouseSensitivity = sens;
    }

    public void HeadBobChange(bool tog)
    {
        headBobEnabled = tog;
    }
}
