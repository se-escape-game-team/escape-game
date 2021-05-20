using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Variables
    public float minutes; // Input Unity
    public float seconds; // Input Unity
    public Text timerText;
    public DefeatMessageScript defeatMessage;

    private float ticks;
    private bool play;
    private bool isTimeOver;



    // Start is called before the first frame update
    void Start()
    {
        ticks = minutes * 60 + seconds;
        play = true; // yust for now
        isTimeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ticks > 0 && play)
        {
            ticks -= Time.deltaTime;
        }
        else if(!isTimeOver)
        {
            isTimeOver = true;
            defeatMessage.ShowDefeatMessage();
        }

        timerText.text = ($"{(int)ticks / 60:D2}:{(int)ticks % 60:D2}");
    }

    public void Pause()
    {
        play = false;
    }
    public void Play()
    {
        play = true;
    }
}

