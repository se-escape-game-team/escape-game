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

    private string passwordWrong = null;
    private string usernameWrong = null;

    public void Start()
    {
        username.text = SaveScript.username;
        if (SaveScript.tries >= 3)
        {
            hintButton.SetActive(true);
        }
        if (SaveScript.hintShown)
        {
            hintText.SetActive(true);
        }
    }

    public void Update()
    {
        // Wenn ein Buchstabe vom falschen Passwort oder Username geaendert wird soll der Text wieder in Farbe schwarz geschrieben sein
        if(passwordWrong != null)
        {
            if(password.text != passwordWrong)
            {
                password.textComponent.color = Color.black;
            }
        }
        if(usernameWrong != null)
        {
            if(username.text != usernameWrong)
            {
                username.textComponent.color = Color.black;
            }
        }

        // Wird die Enter-Taste gedruckt soll der Anmeldevorgang gestartet werden
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Access();
        }
    }

    /// <summary>
    /// Prueft auf korrekte Eingaben
    /// </summary>
    public void Access()
    {
        if (password.text == passwordString && username.text == SaveScript.username)
        {
            Debug.Log("Anmeldung erfolgreich!");
            desktop.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            if (password.text != passwordString)
            {
                password.textComponent.color = Color.red;
                // Speichern des faschen Passworts zum aendern der Schriftfarbe wenn eine Aenderung vorgenommen wurde
                passwordWrong = password.text;
            }
            else
            {
                password.textComponent.color = Color.black;
            }
            if (username.text != SaveScript.username)
            {
                username.textComponent.color = Color.red;
                // Speichern des faschen Usernames zum aendern der Schriftfarbe wenn eine Aenderung vorgenommen wurde
                usernameWrong = username.text;
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

    /// <summary>
    /// Aktiviert den Passwort-Hinweis
    /// </summary>
    public void ShowHint()
    {
        Debug.Log("Show hint");
        hintText.SetActive(true);
        SaveScript.hintShown = true;
    }
}
