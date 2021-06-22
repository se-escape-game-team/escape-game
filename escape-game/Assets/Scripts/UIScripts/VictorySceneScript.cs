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
            $"Gut gemacht!\n" +
            $"Übrige Zeit: {Math.Round(SaveScript.secondsLeft / 60, 0)}:{SaveScript.secondsLeft % 60} Minuten\n";
    }
    
    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }
}