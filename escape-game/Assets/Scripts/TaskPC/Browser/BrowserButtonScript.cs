using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserButtonScript : MonoBehaviour
{
    //Skript für das Browser-App-Icon, um den Browser zu oeffnen

    public void ActivateBrowser()
    {
        SaveScript.browserOpen = true;
        gameObject.SetActive(true);
    }

    public void QuitBrowser()
    {
        gameObject.SetActive(false);
    }
 }
