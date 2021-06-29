using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMessageScript : MonoBehaviour
{
    void Start()
    {
        // Zeigt die Task-Message bei Start der Szene an
        gameObject.SetActive(true);
        PauseMenuScript.pauseMenuAvailable = false;
    }

    void Update()
    {
        // Deaktivieren der Message mit Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Resume();
        }
    }

    /// <summary>
    /// Deaktivieren der Message und zurueckkehren zum Spiel
    /// </summary>
    public void Resume()
    {
        gameObject.SetActive(false);
        PauseMenuScript.pauseMenuAvailable = true;
    }
}
