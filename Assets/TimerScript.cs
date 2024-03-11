using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Very Important Script not created by me. Got Script from https://youtu.be/hxpUk0qiRGs?si=f5-4s9t75HIcWXex
// Video by: The Game Guy
public class TimerScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    public Pink_PlayerManager Pink;
    public Blue_PlayerManager Blue;

    public Text TimerTxt;

    void Start()
    {
        TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                if (Pink.pink_score > Blue.blue_score)
                {
                    TimerTxt.text = "Pink Wins!";
                    TimerTxt.text = "Pink Wins!";
                }
                if (Pink.pink_score < Blue.blue_score)
                {
                    TimerTxt.text = "Blue Wins!";
                    TimerTxt.text = "Blue Wins!";
                }
                if (Pink.pink_score == Blue.blue_score)
                {
                    TimerTxt.text = "Tie!";
                    TimerTxt.text = "Tie!";
                }
            }
        }

    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}