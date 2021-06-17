using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverlayManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory;

    void Update()
    {
        // Ausblenden des Inventars in der PC-Szene
        if (SceneManager.GetActiveScene().name == "TaskPC")
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }
}
