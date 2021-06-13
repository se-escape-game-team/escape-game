using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DoorAccess : MonoBehaviour
{
    public GameObject doorAccess;
    [SerializeField] private Color red = new Color(255, 0, 0, 0);
    [SerializeField] private Color orange = new Color(191, 146, 0, 0);
    [SerializeField] private Color green = new Color(16, 255, 0, 0);

    void Update()
    {
        Material acessMaterial = doorAccess.GetComponent<MeshRenderer>().material;
        if (SaveScript.doorIsOpen == false && SaveScript.hangmanWon == false)
        {
            // Farbe rot einstellen
            acessMaterial.SetColor("_EmissionColor", red);
        }
        else if (SaveScript.doorIsOpen == false && SaveScript.hangmanWon == true)
        {
            // Farbe orange einstellen
            acessMaterial.SetColor("_EmissionColor", orange);
        }
        else if (SaveScript.doorIsOpen == true && SaveScript.hangmanWon == true)
        {
            // Farbe gruen einstellen
            acessMaterial.SetColor("_EmissionColor", green);
        }
    }
}
