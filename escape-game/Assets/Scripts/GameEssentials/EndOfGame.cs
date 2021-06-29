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
        // Wenn der Spieler sich auf dem Trigger im Ausgangstunnel befindet, Endet das Spiel
        if (playerOnTrigger)
        {
            DontDestroyOnLoad[] dontDestroys = GameObject.FindObjectsOfType<DontDestroyOnLoad>();
            foreach (DontDestroyOnLoad d in dontDestroys)
            {
                Destroy(d.gameObject);
            }
            // Curser wird wieder angezeigt
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Victory");
        }
    }

    /// <summary>
    /// Spieler betritt Trigger
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = true;
        }
    }
}
