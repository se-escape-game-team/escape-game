using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //public float minutes;
    //public float seconds;
    public Text timerText;
    public static string timeLeft;
    public DefeatMessageScript defeatMessage;

    void Start()
    {
        if (!SaveScript.timeSet)
        {
            //SaveScript.secondsLeft = minutes * 60 + seconds;
            SaveScript.timeSet = true;
        }
    }

    void Update()
    {
        if (SaveScript.secondsLeft > 0 && !SaveScript.continueAfterDefeat)
        {
            SaveScript.secondsLeft -= Time.deltaTime;
        }
        else if (SaveScript.continueAfterDefeat)
        {
            SaveScript.secondsLeft += Time.deltaTime;
        }
        else
        {
            defeatMessage.ShowDefeatMessage();
        }
        if (!SaveScript.continueAfterDefeat)
        {
            timeLeft = timerText.text = ($"{(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2}");
        }
        else
        {
            timeLeft = timerText.text = ($"-{(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2}");
        }
    }
}

