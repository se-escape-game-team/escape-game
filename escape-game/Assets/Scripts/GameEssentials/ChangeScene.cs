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
        SceneManager.LoadScene(sceneName);
    }

    public static void ChangeSceneBackToLab()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Lab_Room");
    }
}
