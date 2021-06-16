using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour
{
    [SerializeField] Text textArea;
    public GameObject message;
    

    void Start()
    {
        textArea.text = $"Herzlichen Glückwunsch {SaveScript.username}! Du hast es geschafft, aus dem Labor zu fliehen und die KI zu besiegen." +
            $"Gut gemacht!" +
            $"Übrige Zeit: {SaveScript.secondsLeft / 50}:{SaveScript.secondsLeft % 60}";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    public void Resume()
    {
        gameObject.SetActive(false);
    }
}

