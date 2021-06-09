using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMessageScript : MonoBehaviour
{
    [SerializeField] private Crosshair crosshair;

    public void ShowDefeatMessage()
    {
        crosshair.CrosshairEnabled = false;
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        PauseMenuScript.pauseMenuAvailable = false;
    }

    public void Resume()
    {
        SaveScript.continueAfterDefeat = true;
        gameObject.SetActive(false);
        crosshair.CrosshairEnabled = true;
        Time.timeScale = 1f;
        PauseMenuScript.pauseMenuAvailable = true;
    }

    public void Quit()
    { 
        SceneManager.LoadScene("Credits");
    }
}
