using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskMessageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        PauseMenuScript.PauseMenuAvailable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Resume();
        }
    }

    public void Resume()
    {
        gameObject.SetActive(false);
        PauseMenuScript.PauseMenuAvailable = true;
    }




}
