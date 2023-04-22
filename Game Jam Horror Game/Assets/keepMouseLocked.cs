using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMouseLocked : MonoBehaviour
{
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
