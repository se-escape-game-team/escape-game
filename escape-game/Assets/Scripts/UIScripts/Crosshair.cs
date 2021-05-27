using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private GameObject crosshair;
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
