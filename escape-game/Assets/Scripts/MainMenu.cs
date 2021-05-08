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
    }

    // Update is called once per frame
    void Update()
    {
        UserInput();       
    }

    void UserInput()
    {
        username = userField.text;

        if (username.Length > 20)
        {
            errorNameTooLong.SetActive(true);
            isNameValid = false;
        }    
        else 
        {
            errorNameTooLong.SetActive(false);
            isNameValid = true;
        }
        if(username.Length != 0)
        {
            errorNameNull.SetActive(false);
        }
    }    

    public void StartGame()
    {
        if (username.Length == 0)
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
