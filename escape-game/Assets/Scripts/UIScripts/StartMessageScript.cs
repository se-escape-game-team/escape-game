using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMessageScript : MonoBehaviour
{

    public GameObject startMessageOverlay;
    public GameObject crosshair;
    public GameObject pauseMenu;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        crosshair.SetActive(false);
        startMessageOverlay.SetActive(true);
        Time.timeScale = 0f;
        PauseMenuScript.PauseMenuAvailable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Resume();
        }
    }

    public void Resume()
    {
        startMessageOverlay.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PauseMenuScript.PauseMenuAvailable = true;
    }




}