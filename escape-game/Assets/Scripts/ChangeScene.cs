using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeToTaskScene(string sceneName)
    {
        Debug.Log("0");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneName);
        
        Debug.Log("1");
    }

    public void ChangeSceneBackToLab()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Lab_Room");
    }
}
