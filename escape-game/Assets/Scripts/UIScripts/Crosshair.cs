using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;

    private bool crosshairEnabled = false;
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
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                crosshair.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                crosshair.SetActive(true);
            }
            crosshairEnabled = value;
        }
    }
}
