using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{    
    public InputField userField;
    public GameObject errorNameTooLong;
    public GameObject errorNameNull;
    string username;
    bool isNameValid;   
    

    /// <summary>
    /// Username is initialized as an empty string.
    /// </summary>
    void Start()
    {
        username = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Adds the user-input to username.
        if (userField != null && userField.text != null)
        {
            username = UserInput();
        } 
    }

    /// <summary>
    /// Checks the validity of the username, shows error-message if necessary.
    /// </summary>
    /// <returns> valid username </returns>
    string UserInput()
    {
        string _username = userField.text;

        if (_username.Length > 20)
        {
            errorNameTooLong.SetActive(true);
            isNameValid = false;
        }
        else
        {
            errorNameTooLong.SetActive(false);
            isNameValid = true;
        }
        if (_username.Length != 0)
        {
            errorNameNull.SetActive(false);
        }

        return _username;
    }    

    /// <summary>
    /// Starts the game, if username is valid and player presses button.
    /// </summary>
    public void StartGame()
    {
        Time.timeScale = 1f;
        if (username.Length == 0 || username == null)
        {
            errorNameNull.SetActive(true);
        }
        else if(isNameValid)
        {
            SceneManager.LoadScene("Lab_Room");
        }
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void ExitGame()
    {        
        Debug.Log("Quitting...");
        Application.Quit();
    }

    /// <summary>
    /// Shows credit-scene.
    /// </summary>
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
