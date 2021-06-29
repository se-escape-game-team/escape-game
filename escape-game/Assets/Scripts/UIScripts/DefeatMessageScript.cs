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
        // Deaktivieren der Nachricht bei Start der Szene
        foreach (GameObject g in content)
        {
            g.SetActive(false);
        }
    }

    /// <summary>
    /// Zeigt die Defeat-Message an
    /// </summary>
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

    /// <summary>
    /// Laesst das Spiel nach dem Anzeigen der Defeat-Message weiterlaufen
    /// </summary>
    public void Resume()
    {
        SaveScript.continueAfterDefeat = true;

        // Deaktivieren der Nachricht
        foreach (GameObject g in content)
        {
            g.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name == "Lab_Room")
        {
            // Crosshair anzeigen
            crosshair.CrosshairEnabled = true;

            // Uhrzeit aktualisieren
            GameObject clock = GameObject.Find("clock");
            clock.GetComponent<Clock>().SetTime();
        }

        Time.timeScale = 1f;
        SaveScript.pause = false;
        PauseMenuScript.pauseMenuAvailable = true;
    }

    /// <summary>
    /// Beenden des Spiels und Wechseln in die Endszene
    /// </summary>
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
