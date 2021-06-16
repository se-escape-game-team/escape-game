using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Beende das Spiel");
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
