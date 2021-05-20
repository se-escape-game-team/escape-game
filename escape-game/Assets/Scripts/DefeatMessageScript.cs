using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMessageScript : MonoBehaviour
{
    public GameObject defeatMessage;
    public GameObject crosshair;

    void Start()
    {
        defeatMessage.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        
    }

    public void ShowDefeatMessage()
    {
        defeatMessage.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PauseMenuScript.PauseMenuAvailable = false;
    }

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

    public void Quit()
    {
        SceneManager.LoadScene("Credits");
    }



}
