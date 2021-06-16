using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    bool playerOnTrigger;
    // Start is called before the first frame update
    void Start()
    {
        playerOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnTrigger)
        {
            // ToDo Endscreen anzeigen und spiel beenden
            DontDestroyOnLoad[] dontDestroys = GameObject.FindObjectsOfType<DontDestroyOnLoad>();
            foreach (DontDestroyOnLoad d in dontDestroys)
            {
                Destroy(d.gameObject);
            }
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter(Collider col) // Spieler betritt Trigger
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = true;
        }
    }
}
