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
    public string inputnums;

    static public bool KeypadOneComplete;
    static public bool KeypadTwoComplete;


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
    }

    void Update()
    {
        
    }

    public void KeypadPress()
    {
        string lastButtonPressed = EventSystem.current.currentSelectedGameObject.name;
        if (display.text.Length < 4 && (lastButtonPressed != "Enter" && lastButtonPressed != "Back"))
        {
            display.text = (display.text + lastButtonPressed);
        }
        if (lastButtonPressed == "Enter")
        {
            if (!KeypadOneComplete)
            {
                if (display.text == firstPassword)
                {
                    KeypadOneComplete = true;
                    //play success audio
                    InteractionManager.KeypadUI = false;
                    display.text = "";
                    print (KeypadOneComplete);
                }
                else
                {

                }
            }
            else if (KeypadOneComplete && !KeypadTwoComplete)
            {
                if (display.text == secondPassword)
                {
                    KeypadTwoComplete = true;
                }
                else
                {

                }
            }
        }
        if (lastButtonPressed == "Back")
        {
            if (display.text.Length == 0) return;

            display.text = display.text.Substring(0, display.text.Length - 1);
        }
    }
}