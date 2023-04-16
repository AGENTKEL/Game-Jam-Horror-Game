using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    private bool FlashlightOn = true;
    private Light lightswitch;

    void Start()
    {
        lightswitch = gameObject.GetComponent<Light>();
        FlashlightOn = lightswitch;
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
            Flashlightswitch();
    }

    private void Flashlightswitch()
    {
        FlashlightOn = !FlashlightOn;
        switch(FlashlightOn)
        {
            case true:
                lightswitch.enabled = true;
                break;
            case false:
                lightswitch.enabled = false;
                break;
        }

    }
}
