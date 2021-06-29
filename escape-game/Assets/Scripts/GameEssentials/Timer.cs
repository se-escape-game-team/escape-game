using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public static string timeLeft;
    public DefeatMessageScript defeatMessage;

    void Start()
    {
        // Pruefen ob Zeit gesetzt ist
        if (!SaveScript.timeSet)
        {
            SaveScript.timeSet = true;
        }
    }

    void Update()
    {
        // Zeit herunter Zaehlen, wenn Zeit noch nicht abgelaufen
        if (SaveScript.secondsLeft > 0 && !SaveScript.continueAfterDefeat)
        {
            SaveScript.secondsLeft -= Time.deltaTime;
        }
        // Wenn der Spielende nach abgelaufener Zeit weiterspielt, Zeit negativ weiterzaehlen
        else if (SaveScript.continueAfterDefeat)
        {
            SaveScript.secondsLeft += Time.deltaTime;
        }
        // sonst Defeat Message anzeigen
        else
        {
            defeatMessage.ShowDefeatMessage();
        }

        // Text fuer Timer uebergeben
        // vor ablauf der Zeit
        if (!SaveScript.continueAfterDefeat)
        {
            timeLeft = timerText.text = ($"{(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2}");
        }
        // nach ablauf der Zeit
        else
        {
            timeLeft = timerText.text = ($"-{(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2}");
        }
    }
}