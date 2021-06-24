using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VictorySceneScript : MonoBehaviour
{
    [SerializeField] Text textArea;

    void Start()
    {
        textArea.text = $"Herzlichen Glückwunsch {SaveScript.username}!\n" +
            $"Du hast es geschafft, aus dem Labor zu fliehen und die KI zu besiegen.\n" +
            $"Gut gemacht!\n";
        if (!SaveScript.continueAfterDefeat)
        {
            textArea.text += $"Übrige Zeit: {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten\n";
        }
        else
        {
            textArea.text += $"Du hast {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten zu lange gebraucht.\n";
        }
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}