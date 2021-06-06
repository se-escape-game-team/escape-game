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
