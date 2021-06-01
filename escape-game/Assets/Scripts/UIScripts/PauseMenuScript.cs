using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private SelectObjects selectObjects;
    public static bool GameIsPaused;
    public static bool PauseMenuAvailable;
    public GameObject pauseMenuUI;
    public GameObject Overlay;
    public GameObject startMessage;   

    /// <summary>
    /// The game is not  paused and the PauseMenu can be shown.
    /// </summary>
    private void Start()
    {       
        GameIsPaused = false;
        PauseMenuAvailable = true;
    }

    /// <summary>
    /// Show and Quit PauseMenu by clicking Esc.
    /// </summary>
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenuAvailable)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    /// <summary>
    /// The PauseMenu gets activated, the game pauses and the Cursor changes its state.
    /// </summary>
    void Pause()
    {
        Overlay.SetActive(false);
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        startMessage.SetActive(false);
    }

    /// <summary>
    /// Undos all the changes of the Pause() method.
    /// </summary>
    public void Resume()
    {
        Overlay.SetActive(true);
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }    

    /// <summary>
    /// Loads MainMenu-scene.
    /// </summary>
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenue");
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }



}