using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{

    public GameObject movingDoor;

    public float maximumOpening = 1.2f;
    public float maximumClosing = 0f;

    public float movementSpeed = 1f;

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
            //Debug.Log("blala");
            Debug.Log(movingDoor.transform.position.z);
            if (movingDoor.transform.position.z < maximumOpening)
            {
                movingDoor.transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
            }
        }
        else
        {
            //Debug.Log("blub");
            if (movingDoor.transform.position.z > maximumClosing)
            {
                Debug.Log("Tür schließen");
                movingDoor.transform.Translate(0f, 0f, - movementSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
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
