using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lockscreen : MonoBehaviour
{
    [SerializeField] private InputField username;
    [SerializeField] private InputField password;
    [SerializeField] private GameObject desktop;
    [SerializeField] private GameObject hintButton;
    [SerializeField] private GameObject hintText;

    private string passwordString = "GeNiUS";

    public void Start()
    {
        username.text = SaveScript.username;
        if(SaveScript.tries >= 3)
        {
            hintButton.SetActive(true);
        }
        if (SaveScript.hintShown)
        {
            hintText.SetActive(true);
        }
    }

    public void Access()
    {
        if(password.text == passwordString && username.text == SaveScript.username)
        {
            Debug.Log("Anmeldung erfolgreich!");
            desktop.SetActive(true);
            this.enabled = false;
        }
        else
        {
            if(password.text != passwordString)
            {
                password.textComponent.color = Color.red;
            }
            else
            {
                password.textComponent.color = Color.black;
            }
            if(username.text != SaveScript.username)
            {
                username.textComponent.color = Color.red;
            }
            else
            {
                username.textComponent.color = Color.black;
            }

            SaveScript.tries++;

            if (SaveScript.tries >= 3)
            {
                Debug.Log("Enable hint");
                hintButton.SetActive(true);
            }
            Debug.Log("Anmeldung fehlgeschlagen!" + SaveScript.tries);
        }
    }

    public void ShowHint()
    {
        Debug.Log("Show hint");
        hintText.SetActive(true);
        SaveScript.hintShown = true;
    }
}
