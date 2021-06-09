using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool pauseMenuAvailable = true;
    public GameObject pauseMenuUI;
    public GameObject overlay;

    private bool gameIsPaused = false;

    private void Start()
    {
        // Deaktiviert das Pause-Menue beim Starten der Szene
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuAvailable)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
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

        // Lockt den Cursor in der Mitte vom Bild
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        // Deaktiviert das Overlay
        overlay.SetActive(false);
        
        // Aktiviert das Pause-Menue
        pauseMenuUI.SetActive(true);

        // Schaltet den Cursor frei
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Spiel beenden.");
        Application.Quit();
    }
}