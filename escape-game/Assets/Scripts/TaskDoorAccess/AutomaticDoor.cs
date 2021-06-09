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

    // Start is called before the first frame update
    void Start()
    {
        originX = movingDoor.transform.position.x;
        playerOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(movingDoor.transform.position);
        if (SaveScript.doorIsOpen)
        {
            if (playerOnTrigger)
            {
                //Debug.Log("blala");
                if (movingDoor.transform.position.x < maximumOpening + originX)
                {
                    //Debug.Log("Tür öffnen");
                    movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (movingDoor.transform.position.x > originX)
                {
                    //Debug.Log("Tür schließen");
                    movingDoor.transform.Translate(0f, 0f, -movementSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerOnTrigger = false;
        }
    }
}
