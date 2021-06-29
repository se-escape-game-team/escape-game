using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanButton : MonoBehaviour
{
    //Skript für das Hangman-App-Icon, um das Spiel zu oeffnen

    public void OpenHangmanApplication()
    {
        gameObject.SetActive(true);
    }

    public void CloseHangmanApplication()
    {
        gameObject.SetActive(false);
    }
}
