using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject Overlay;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {       
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
        Overlay.SetActive(true);
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Overlay.SetActive(false);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void LoadMainMenu()
    {
        Debug.Log("Loading Main Menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }



}
