using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void ChangeToTaskScene(string sceneName)
    {
        // Speichern der Spielerposition
        SaveScript.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Speichern der Rotation des Spielers
        SaveScript.playerRotationY = GameObject.FindGameObjectWithTag("Player").transform.rotation.eulerAngles.y;
        Debug.Log(SaveScript.playerRotationY);

        // Speichern der Rotation der Kamera
        SaveScript.camerRotationX = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.eulerAngles.x;
        Debug.Log(SaveScript.camerRotationX);

        SceneManager.LoadScene(sceneName);

        GameObject.Find("Overlay").GetComponent<Crosshair>().CrosshairEnabled = false;
    }

    public static void ChangeSceneBackToLab()
    { 
        SceneManager.LoadScene("Lab_Room");
        GameObject.Find("Overlay").GetComponent<Crosshair>().CrosshairEnabled = true;
    }
}
