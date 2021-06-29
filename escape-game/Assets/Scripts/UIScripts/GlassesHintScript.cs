using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesHintScript : MonoBehaviour
{
    [SerializeField] Crosshair crosshair;
    [SerializeField] GameObject hint;

    void Update()
    {
        // Anzeigen des Tipps fuer die Brille nachdem 10% der Zeit abgelaufen sind und die Brille noch nicht eingesammelt wurde
        if (SaveScript.secondsLeft <= SaveScript.totalTime * 0.9 && !SaveScript.glassesHintWasShown && !SaveScript.glassesCollected)
        {
            hint.SetActive(true);
            crosshair.CrosshairEnabled = false;
            Time.timeScale = 0f;
            SaveScript.pause = true;
            PauseMenuScript.pauseMenuAvailable = false;
            SaveScript.glassesHintWasShown = true;
        }
    }

    /// <summary>
    /// Schliessen der Nachricht und zurueckkehren zum Spiel
    /// </summary>
    public void Resume()
    {
        hint.SetActive(false);
        crosshair.CrosshairEnabled = true;
        Time.timeScale = 1f;
        SaveScript.pause = false;
        PauseMenuScript.pauseMenuAvailable = true;
    }
}
