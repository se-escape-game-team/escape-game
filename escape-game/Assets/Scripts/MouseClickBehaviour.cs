using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary Button.");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed secondary Button.");
        }
    }

    private void OnMouseDown()
    {
        //interact with GameObject
    }
}
