using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /// <summary>
    /// Wechsel in "Raetsel Szene" und speichern der Position des Spielenden
    /// </summary>
    /// <param name="sceneName"></param>
    public static void ChangeToTaskScene(string sceneName)
    {
        // Speichern der Spielerposition
        SaveScript.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Speichern der Rotation des Spielers
        SaveScript.playerRotationY = GameObject.FindGameObjectWithTag("Player").transform.rotation.eulerAngles.y;

        // Speichern der Rotation der Kamera
        SaveScript.camerRotationX = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.eulerAngles.x;
        
        // Overlay wird ausgeblendet
        GameObject.Find("Overlay").GetComponent<Crosshair>().CrosshairEnabled = false;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Wechsel zurueck in die Labor Szene
    /// </summary>
    public static void ChangeSceneBackToLab()
    { 
        SceneManager.LoadScene("Lab_Room");
    }
}
