using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartMessageScript : MonoBehaviour
{
    private Crosshair crosshair;
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = $@"Anscheinend ist etwas schiefgelaufen! Es gab eine Explosion!

Du befindest dich in einem hermetisch abgeriegelten Labor. Normalerweise beschäftigst Du, Professor Doktor {SaveScript.username}, Dich hier mit der Erforschung fremder Galaxien.

Bei der Untersuchung von Marsgestein ist Dir ein verheerender Fehler unterlaufen, das Labor wird Dir nur für {(int)SaveScript.secondsLeft / 60:D2} Minuten ausreichend Sauerstoff bieten. Löse alle Rätsel, um dich zu befreien!

Und dann ist da auch noch die KI …";

        crosshair = GameObject.Find("Overlay").GetComponent<Crosshair>();
        // Ueberpruefen ob die Nachricht bereits angezeigt wurde
        if (!SaveScript.startMessageWasShown)
        {
            // Schalte Crosshair aus
            crosshair.CrosshairEnabled = false;

            // Halte Zeit an
            Time.timeScale = 0f;

            // Verweigere Zugriff auf Pause-Menue
            PauseMenuScript.pauseMenuAvailable = false;
        }
        else
        {
            // Zeigt Nachricht nicht an und startet direkt die Szene
            gameObject.SetActive(false);
            Resume();
        }
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
        // Speichert, dass die Startnachricht angezeigt wurde
        SaveScript.startMessageWasShown = true;

        // Deaktiviert die Nachricht
        gameObject.SetActive(false);

        // Zeigt das Crosshair an
        crosshair.CrosshairEnabled = true;

        // Laestt die Zeit weiterlaufen
        Time.timeScale = 1f;

        // Schaltet das Pause-Menue frei
        PauseMenuScript.pauseMenuAvailable = true;
    }
}
