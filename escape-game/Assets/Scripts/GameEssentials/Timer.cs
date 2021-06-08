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
    public static string timeLeft;
    public DefeatMessageScript defeatMessage;

    private float ticks;
    private bool play;
    private bool isTimeOver;



    // Start is called before the first frame update
    void Start()
    {
        SaveScript.secondsLeft = minutes * 60 + seconds;
        play = true; // yust for now
        isTimeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.secondsLeft > 0 && play)
        {
            SaveScript.secondsLeft -= Time.deltaTime;
        }
        else if(!isTimeOver)
        {
            isTimeOver = true;
            defeatMessage.ShowDefeatMessage();
        }

        timeLeft = timerText.text = ($"{(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2}");
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

