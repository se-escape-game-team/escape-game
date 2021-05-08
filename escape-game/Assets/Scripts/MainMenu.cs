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
    
    public string Username
    {
        get { return username; }
    }

    // Start is called before the first frame update
    void Start()
    {
        errorNameTooLong.SetActive(false);
        errorNameNull.SetActive(false);
        username = "";
    }

    // Update is called once per frame
    void Update()
    {
        username =UserInput();     
    }

    string UserInput()
    {
        string _username = userField.text;

        if (userField.text != null)
        {
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
        }

        return _username;
    }    

    public void StartGame()
    {
        if (username.Length == 0 || username == null)
        {
            errorNameNull.SetActive(true);
        }
        else if(isNameValid)
        {
            SceneManager.LoadScene("Lab_Room");
        }
    }

    public void doExitGame()
    {        
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
