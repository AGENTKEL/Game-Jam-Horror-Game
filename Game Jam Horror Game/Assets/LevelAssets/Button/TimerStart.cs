using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerStart: MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 120f;

    [SerializeField] TextMeshProUGUI CountDownText;
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;

            string Minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string Seconds = (currentTime % 60).ToString("00");

            
            CountDownText.text = string.Format("{0}:{1}", Minutes, Seconds);
        }
    }
}
