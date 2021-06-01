using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMessageScript : MonoBehaviour
{
    public GameObject defeatMessage;
    public GameObject crosshair;

    /// <summary>
    /// When the time is over, the defeat message appears.
    /// </summary>
    public void ShowDefeatMessage()
    {
        defeatMessage.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PauseMenuScript.PauseMenuAvailable = false;
    }

    /// <summary>
    /// Undos  all changes of the ShowDefeatMessage() method.
    /// </summary>
    public void Resume()
    {
        Debug.Log("test");
        defeatMessage.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenuScript.PauseMenuAvailable = true;
    }

    /// <summary>
    /// Loads the Credits-scene.
    /// </summary>
    public void Quit()
    {
        SceneManager.LoadScene("Credits");
    }



}
