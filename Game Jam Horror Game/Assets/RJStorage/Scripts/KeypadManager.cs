using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    private int IpasswordOne;
    private int IpasswordTwo;

    static public string firstPassword;
    static public string secondPassword;


    public GameObject KeypadOne;
    public GameObject KeypadTwo;

    public TMPro.TextMeshProUGUI display;

    public TMPro.TextMeshPro note1;
    public TMPro.TextMeshPro note2;

    static public bool KeypadOneComplete;
    static public bool KeypadTwoComplete;

    public AudioClip successClip;
    public AudioClip failClip;
    public AudioClip buttonPress = default;

    private AudioSource audiosrc;

    public AudioClip bunkerdoorunlockSound;


    void Awake()
    {
        IpasswordOne = Random.Range(0, 10000);
        IpasswordTwo = Random.Range(0, 10000);
    }

    void Start() 
    {
        if (IpasswordOne == IpasswordTwo)
            IpasswordTwo = Random.Range(0, 10000);
        firstPassword = System.String.Format("{0:0000}", IpasswordOne);
        secondPassword = System.String.Format("{0:0000}", IpasswordTwo);
        print (firstPassword);
        print (secondPassword);
        audiosrc = KeypadOne.GetComponent<AudioSource>();
        note1.text = firstPassword;
        note2.text = secondPassword;
    }

    void Update()
    {
        if (InteractionManager.KeypadUI == false)
            display.text = "";
    }

    public void KeypadPress()
    {
        string lastButtonPressed = EventSystem.current.currentSelectedGameObject.name;
        if (display.text.Length < 4 && (lastButtonPressed != "Enter" && lastButtonPressed != "Back"))
        {
            audiosrc.PlayOneShot(buttonPress);
            display.text = (display.text + lastButtonPressed);
        }
        if (lastButtonPressed == "Enter")
        {
            if (!KeypadOneComplete)
            {
                if (display.text == firstPassword)
                {
                    KeypadOneComplete = true;
                    audiosrc.clip = successClip;
                    audiosrc.Play();
                    InteractionManager.KeypadUI = false;
                    display.text = "";
                    audiosrc = KeypadTwo.GetComponent<AudioSource>();
                }
                else
                {
                    audiosrc.clip = failClip;
                    audiosrc.Play();
                    display.text = "";
                }
            }
            else if (KeypadOneComplete && !KeypadTwoComplete)
            {
                if (display.text == secondPassword)
                {
                    KeypadTwoComplete = true;
                    audiosrc.clip = successClip;
                    audiosrc.Play();
                    InteractionManager.KeypadUI = false;
                    display.text = "";
                }
                else
                {
                    audiosrc.clip = failClip;
                    audiosrc.Play();
                    display.text = "";
                }
            }
        }
        if (lastButtonPressed == "Back")
        {
            if (display.text.Length == 0) return;
            audiosrc.clip = buttonPress;
            audiosrc.Play();
            display.text = display.text.Substring(0, display.text.Length - 1);
        }
    }
}
