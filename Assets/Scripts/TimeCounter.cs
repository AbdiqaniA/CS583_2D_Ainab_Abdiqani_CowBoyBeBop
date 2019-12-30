using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    Text timeUI;
    float startTime;
    float currentTime;
    bool startCount;

    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCount = false;
        timeUI = GetComponent<Text>();
    }

    public void startCounter()
    {
        startTime = Time.time;
        startCount = true;
    }
    public void stopTime()
    {
        startCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCount)
        {
            currentTime = Time.time - startTime;
            minutes = (int)currentTime / 60;
            seconds= (int) currentTime % 60;

            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
