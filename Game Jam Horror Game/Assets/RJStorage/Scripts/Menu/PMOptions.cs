using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PMOptions : MonoBehaviour
{

    public Slider audioSlide;
    public Slider mouse;
    public Toggle headbob;

    public AudioMixer mixer;

    void Start()
    {
        audioSlide.value = MMOptions.audioVolume;
        mouse.value = MMOptions.mouseSensitivity;
        headbob.isOn = MMOptions.headBobEnabled;
    }

    public void AudioChange(System.Single vol)
    {
        mixer.SetFloat ("SoundVol", Mathf.Log10 (vol) * 20);
    }

    public void MouseChange(System.Single sens)
    {
        MMOptions.mouseSensitivity = sens;
    }

    public void HeadBobChange(bool tog)
    {
        MMOptions.headBobEnabled = tog;
    }
}