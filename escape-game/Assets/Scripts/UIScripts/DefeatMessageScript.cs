using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMessageScript : MonoBehaviour
{
    [SerializeField] private Crosshair crosshair;
    [SerializeField] private GameObject[] content;

    private void Start()
    {
        foreach (GameObject g in content)
        {
            g.SetActive(false);
        }
    }
    public void ShowDefeatMessage()
    {
        crosshair.CrosshairEnabled = false;
        foreach(GameObject g in content)
        {
            g.SetActive(true);
        }
        Time.timeScale = 0f;
        SaveScript.pause = true;
        PauseMenuScript.pauseMenuAvailable = false;
    }

    public void Resume()
    {
        SaveScript.continueAfterDefeat = true;
        foreach (GameObject g in content)
        {
            g.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Lab_Room")
        {
            crosshair.CrosshairEnabled = true;

            // Aktualisiert die Uhrzeit
            GameObject clock = GameObject.Find("clock");
            clock.GetComponent<Clock>().SetTime();
        }
        Time.timeScale = 1f;
        SaveScript.pause = false;
        PauseMenuScript.pauseMenuAvailable = true;
    }

    public void Quit()
    {
        // Loesche alle Objekte die ueber Szenenwechsel hinweg leben
        DontDestroyOnLoad[] dontDestroyObjects = GameObject.FindObjectsOfType<DontDestroyOnLoad>();
        foreach(DontDestroyOnLoad d in dontDestroyObjects)
        {
            Destroy(d.gameObject);
        }
        SceneManager.LoadScene("Credits");
    }
}
