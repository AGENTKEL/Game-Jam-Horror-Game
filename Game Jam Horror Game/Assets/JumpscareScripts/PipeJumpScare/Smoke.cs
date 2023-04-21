using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySmoke", 7f);
    }

    public void DestroySmoke()
    {
        Destroy(gameObject);
    }

}
