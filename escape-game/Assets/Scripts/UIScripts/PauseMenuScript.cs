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
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuAvailable)
        {
            if (!SaveScript.pause)
            {
                Pause();

            }
        }
    }

    public void Resume()
    {
        // Aktiviert das Overlay
        overlay.SetActive(true);

        // Deaktiviert das Pause-Menue
        pauseMenuUI.SetActive(false);
        backgroundPanel.SetActive(false);

        if(SceneManager.GetActiveScene().name == "Lab_Room")
        {
            // Lockt den Cursor in der Mitte vom Bild
            Cursor.lockState = CursorLockMode.Locked;
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

    void Pause()
    {
        // Aktualisieren der angezeigten uebrigen Zeit
        if (!SaveScript.continueAfterDefeat)
        {
            timeLeft.text = $"Du hast noch {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten Zeit...";
        }
        else
        {
            timeLeft.text = $"Du bist {(int)SaveScript.secondsLeft / 60:D2}:{(int)SaveScript.secondsLeft % 60:D2} Minuten �ber der Zeit...";
        }

        // Deaktiviert den BackToLab-Button
        backToLabButton = GameObject.FindGameObjectWithTag("BackToLabButton");
        if(backToLabButton != null)
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

    public void QuitGame()
    {
        Debug.Log("Spiel beenden.");
        Application.Quit();
    }
}