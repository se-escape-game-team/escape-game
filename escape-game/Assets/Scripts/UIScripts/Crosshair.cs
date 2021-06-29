using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;

    private bool crosshairEnabled = false;

    /// <summary>
    /// Gibt an ob das Crosshair angezeigt wird und laesst es ein- und ausschalten
    /// </summary>
    public bool CrosshairEnabled
    {
        get
        {
            return crosshairEnabled;
        }
        set
        {
            if(value == false)
            {
                // Crosshair ausblenden + Einstellungen fuer Mauszeiger
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                crosshair.SetActive(false);
            }
            else
            {
                // Crosshair einblenden + Einstellungen fuer Mauszeiger
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                crosshair.SetActive(true);
            }
            crosshairEnabled = value;
        }
    }
}
