using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMessageScript : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(true);
        PauseMenuScript.pauseMenuAvailable = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Resume();
        }
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        PauseMenuScript.pauseMenuAvailable = true;
    }
}
