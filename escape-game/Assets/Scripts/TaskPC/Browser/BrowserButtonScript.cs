using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserButtonScript : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateBrowser()
    {
        gameObject.SetActive(true);
    }

    public void QuitBrowser()
    {
        gameObject.SetActive(false);
    }
 }
