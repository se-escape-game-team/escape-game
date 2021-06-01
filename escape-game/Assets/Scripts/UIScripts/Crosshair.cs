using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;

    /// <summary>
    /// Checks, wether the crosshair is shown or not; changes its visibility.
    /// </summary>
    public void CheckIfEnabled()
    {
        if (!SaveScript.InLabScene)
        {
            Debug.Log("Disable Crosshair");
            crosshair.SetActive(false);
        }
        else
        {
            Debug.Log("Enable Crosshair");
            crosshair.SetActive(true);
        }
    }
}
