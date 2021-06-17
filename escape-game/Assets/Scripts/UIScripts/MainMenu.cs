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
    public Dropdown difficutly;
    
    
    
    
    public string Username
    {
        get
        {
            Debug.Log("Userneme was accessed");
            return username;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        username = "";
    }

    // Update is called once per frame
    void Update()
    {

        if (userField != null && userField.text != null)
        {
            username = UserInput();
        }

        int input = difficutly.value;
        switch (input)
        {
            case 0: SaveScript.secondsLeft = 25 * 60;
                break;
            case 1:
                SaveScript.secondsLeft = 20 * 60;
                break;
            case 2:
                SaveScript.secondsLeft = 15 * 60;
                break;
            default: throw new System.IndexOutOfRangeException();
        }
    }

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

    public void StartGame()
    {
        Time.timeScale = 1f;
        if (username.Length == 0 || username == null)
        {
            errorNameNull.SetActive(true);
        }
        else if(isNameValid)
        {
            SaveScript.username = username;
            SceneManager.LoadScene("Lab_Room");
        }
    }

    public void doExitGame()
    {        
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
