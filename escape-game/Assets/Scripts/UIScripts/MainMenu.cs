using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField userField;
    public GameObject errorNameTooLong;
    public GameObject errorNameNull;
    string username;
    bool isNameValid;
    public Dropdown difficutly;

    void Start()
    {
        username = "";
    }

    void Update()
    {
        // Aktualisieren des User-Inputs
        if (userField != null && userField.text != null)
        {
            username = UserInput();
        }

        // Zeit der ausgewaehlten Schwierigkeit nach setzen
        if (difficutly != null)
        {
            int input = difficutly.value;
            switch (input)
            {
                case 0:
                    // Leicht (35 Minuten)
                    SaveScript.secondsLeft = 35 * 60 + 1;
                    break;
                case 1:
                    // Mittel (30 Minuten)
                    SaveScript.secondsLeft = 30 * 60 + 1;
                    break;
                case 2:
                    // Schwer (25 Minuten)
                    SaveScript.secondsLeft = 25 * 60 + 1;
                    break;
                default: throw new System.IndexOutOfRangeException();
            }
            SaveScript.totalTime = SaveScript.secondsLeft;
        }
    }

    /// <summary>
    /// Ueberpruefen des Inputs und anzeigen moeglicher Fehler
    /// </summary>
    /// <returns>User-Input username</returns>
    string UserInput()
    {
        string _username = userField.text;

        if (_username.Length > 20)
        {
            errorNameTooLong.SetActive(true);
            isNameValid = false;
        }
        else
        {
            errorNameTooLong.SetActive(false);
            isNameValid = true;
        }

        if (_username.Length != 0)
        {
            errorNameNull.SetActive(false);
        }

        return _username;
    }

    /// <summary>
    /// Starten des Spiels und Ueberpruefen ob der Name richtig gesetzt ist
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        // Ueberpruefen des Namens
        if (username.Length == 0 || username == null)
        {
            errorNameNull.SetActive(true);
        }
        else if (isNameValid)
        {
            SaveScript.username = username;
            SceneManager.LoadScene("Lab_Room");
        }
    }

    /// <summary>
    /// Verlassen des Spiels
    /// </summary>
    public void DoExitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Wechseln in Credit-Szene
    /// </summary>
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
