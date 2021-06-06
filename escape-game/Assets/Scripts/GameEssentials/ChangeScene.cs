using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void ChangeToTaskScene(string sceneName)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SaveScript.InLabScene = false;

        // Speichern der Spielerposition
        SaveScript.PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Speichern der Rotation des Spielers
        SaveScript.PlayerRotationY = GameObject.FindGameObjectWithTag("Player").transform.rotation.eulerAngles.y;
        Debug.Log(SaveScript.PlayerRotationY);

        // Speichern der Rotation der Kamera
        SaveScript.CamerRotationX = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.eulerAngles.x;
        Debug.Log(SaveScript.CamerRotationX);

        SceneManager.LoadScene(sceneName);

        GameObject.Find("Overlay").GetComponent<Crosshair>().CheckIfEnabled();
    }

    public static void ChangeSceneBackToLab()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SaveScript.InLabScene = true;
        SceneManager.LoadScene("Lab_Room");

        GameObject.Find("Overlay").GetComponent<Crosshair>().CheckIfEnabled();
    }
}
