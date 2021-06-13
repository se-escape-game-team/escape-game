using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserButtonScript : MonoBehaviour
{   
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
