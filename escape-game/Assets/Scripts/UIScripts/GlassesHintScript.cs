using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesHintScript : MonoBehaviour
{
    [SerializeField] Crosshair crosshair;
    [SerializeField] GameObject hint;

    void Update()
    {
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

    public void Resume()
    {
        hint.SetActive(false);
        crosshair.CrosshairEnabled = true;
        Time.timeScale = 1f;
        SaveScript.pause = false;
        PauseMenuScript.pauseMenuAvailable = true;
    }
}
