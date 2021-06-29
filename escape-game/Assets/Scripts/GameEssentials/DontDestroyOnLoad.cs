using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private string objectID;

    /// <summary>
    /// Wird einmalig vor "void Start()" aufgerufen
    /// </summary>
    private void Awake()
    {
        // Speichert den Objektnamen und die Position
        objectID = name + transform.position.ToString();
    }

    void Start()
    {
        // Uebernimmt Objekte in andere Szene
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroyOnLoad>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroyOnLoad>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroyOnLoad>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}