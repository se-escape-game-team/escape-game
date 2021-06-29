using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public GameObject movingDoor;
    private float originX;
    public float maximumOpening = 1.5f;

    public float movementSpeed = 1f;

    bool playerOnTrigger;

    void Start()
    {
        originX = movingDoor.transform.position.x;
        playerOnTrigger = false;
    }

    void Update()
    {
        if (SaveScript.doorIsOpen)
        {
            if (playerOnTrigger)
            {

                if (movingDoor.transform.position.x < maximumOpening + originX) // Tuer oeffnet sich
                {
                    movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (movingDoor.transform.position.x > originX) // Tuer schliesst sich
                {
                    movingDoor.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider col) // Spieler betritt Trigger
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col) // Spieler verlässtTrigger
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = false;
        }
    }
}