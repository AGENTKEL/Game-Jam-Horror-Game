using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadManager : MonoBehaviour
{
    private int passwordOne;
    private int passwordTwo;

    static public string firstPassword;
    static public string secondPassword;


    public GameObject KeypadOne;
    public GameObject KeypadTwo;

    private bool KeypadOneComplete;
    private bool KeypadTwoComplete;

    void Awake()
    {
        passwordOne = Random.Range(0, 10000);
        passwordTwo = Random.Range(0, 10000);
    }

    void Start() 
    {
        if (passwordOne == passwordTwo)
            passwordTwo = Random.Range(0, 10000);
        firstPassword = System.String.Format("{0:0000}", passwordOne);
        secondPassword = System.String.Format("{0:0000}", passwordTwo);
    }

    void Update()
    {
        
    }
}
