using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class VictorySceneScript : MonoBehaviour
{
    [SerializeField] Text textArea;

    void Start()
    {
        textArea.text = $"Herzlichen Gl?ckwunsch {SaveScript.username}!\n" +
            $"Du hast es geschafft, aus dem Labor zu fliehen und die KI zu besiegen.\n" +
            $"Gut gemacht!\n";

        // Anpassen der Nachricht je nachdem ob man das Spiel in der vorgegebenen Zeit geschafft hat oder nicht
        if (!SaveScript.continueAfterDefeat)
        {
            textArea.text += $"Uebrige Zeit: {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten\n";
        }
        else
        {
            textArea.text += $"Du hast {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten zu lange gebraucht.\n";
        }
    }

    /// <summary>
    /// Wechsel in Credits-Szene
    /// </summary>
    public void QuitApplication()
    {
        SceneManager.LoadScene("Credits");
    }
}