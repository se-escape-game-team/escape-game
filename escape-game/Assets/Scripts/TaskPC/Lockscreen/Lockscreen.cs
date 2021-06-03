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
        username.text = SaveScript.Username;
        if(SaveScript.Tries >= 3)
        {
            hintButton.SetActive(true);
        }
        if (SaveScript.HintShown)
        {
            hintText.SetActive(true);
        }
    }

    public void Access()
    {
        if(password.text == passwordString && username.text == SaveScript.Username)
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
            if(username.text != SaveScript.Username)
            {
                username.textComponent.color = Color.red;
            }
            else
            {
                username.textComponent.color = Color.black;
            }

            SaveScript.Tries++;

            if (SaveScript.Tries >= 3)
            {
                Debug.Log("Enable hint");
                hintButton.SetActive(true);
            }
            Debug.Log("Anmeldung fehlgeschlagen!" + SaveScript.Tries);
        }
    }

    public void ShowHint()
    {
        Debug.Log("Show hint");
        hintText.SetActive(true);
        SaveScript.HintShown = true;
    }
}
