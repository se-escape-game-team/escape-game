using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject overlay;
    [SerializeField] private Text timeLeft;

    /// <summary>
    /// Gibt an ob das Pause-Menue gerade verfuegbar ist oder nicht
    /// </summary>
    public static bool pauseMenuAvailable = true;

    private GameObject backToLabButton;

    private void Start()
    {
        // Deaktiviert das Pause-Menue beim Starten der Szene
        pauseMenuUI.SetActive(false);
        backgroundPanel.SetActive(false);
    }

    void Update()
    {
        // Wenn Escape gedrueckt wird soll das Pause-Menue geoeffnet werden
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuAvailable)
        {
            if (!SaveScript.pause)
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Methode zum Zurueckkehren zum Spiel
    /// </summary>
    public void Resume()
    {
        // Aktiviert das Overlay
        overlay.SetActive(true);

        // Deaktiviert das Pause-Menue
        pauseMenuUI.SetActive(false);
        backgroundPanel.SetActive(false);

        // Aktualisiert die Uhrzeit
        GameObject clock = GameObject.Find("clock");
        if (clock != null)
        {
            clock.GetComponent<Clock>().SetTime();
        }

        if (SceneManager.GetActiveScene().name == "Lab_Room")
        {
            // Lockt den Cursor in der Mitte vom Bild
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Aktiviert den BackToLab-Button
        if (backToLabButton != null)
        {
            backToLabButton.SetActive(true);
            backToLabButton = null;
        }

        Time.timeScale = 1f;
        SaveScript.pause = false;
    }

    /// <summary>
    /// Methode zum Aktivieren des Pause-Menues
    /// </summary>
    void Pause()
    {
        // Aktualisieren der angezeigten uebrigen Zeit
        if (!SaveScript.continueAfterDefeat)
        {
            timeLeft.text = $"Du hast noch {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten Zeit...";
        }
        else
        {
            timeLeft.text = $"Du bist {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten über der Zeit...";
        }

        // Deaktiviert den BackToLab-Button
        backToLabButton = GameObject.FindGameObjectWithTag("BackToLabButton");
        if (backToLabButton != null)
        {
            backToLabButton.SetActive(false);
        }

        // Deaktiviert das Overlay
        overlay.SetActive(false);

        // Aktiviert das Pause-Menue
        pauseMenuUI.SetActive(true);
        backgroundPanel.SetActive(true);

        // Schaltet den Cursor frei
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        Time.timeScale = 0f;
        SaveScript.pause = true;
    }

    /// <summary>
    /// Methode zum Verlassen des Spiels
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}