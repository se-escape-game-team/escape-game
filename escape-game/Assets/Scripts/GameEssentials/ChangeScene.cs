using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void ChangeToTaskScene(string sceneName)
    {
        SaveScript.PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        SaveScript.PlayerRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
        SaveScript.CameraRotation = GameObject.FindGameObjectWithTag("MainCamera").transform.rotation;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SaveScript.InLabScene = false;
        SceneManager.LoadScene(sceneName);

        Debug.Log(SaveScript.PlayerPosition);
        Debug.Log(SaveScript.PlayerRotation);
        Debug.Log(SaveScript.CameraRotation);

        GameObject.Find("Overlay").GetComponent<Crosshair>().CheckIfEnabled();
    }

    public static void ChangeSceneBackToLab()
    {
        Debug.Log(SaveScript.PlayerPosition);
        Debug.Log(SaveScript.PlayerRotation);
        Debug.Log(SaveScript.CameraRotation);

        Cursor.lockState = CursorLockMode.Locked;
        SaveScript.InLabScene = true;
        SceneManager.LoadScene("Lab_Room");

        GameObject.Find("Overlay").GetComponent<Crosshair>().CheckIfEnabled();
    }
}
