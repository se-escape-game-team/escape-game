using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    public GameObject triggerEnd;

    void Update()
    {
        if(triggerEnd.activeSelf)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
