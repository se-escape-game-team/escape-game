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

        // Anpassen der Nachricht je nachdem ob man das Spiel in der vorgegebenen Zeit geschafft hat oder nicht
        if (!SaveScript.continueAfterDefeat)
        {
            textArea.text += $"Übrige Zeit: {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten\n";
        }
        else
        {
            textArea.text += $"Du hast {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten zu lange gebraucht.\n";
        }
    }

    /// <summary>
    /// Beenden des Spiels
    /// </summary>
    public void QuitApplication()
    {
        Application.Quit();
    }
}