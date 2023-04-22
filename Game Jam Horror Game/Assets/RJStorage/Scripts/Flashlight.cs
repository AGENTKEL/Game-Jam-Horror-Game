using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light lightswitch;

    void Awake() 
    {
        lightswitch = gameObject.GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            lightswitch.enabled = !lightswitch.enabled;
    }
}