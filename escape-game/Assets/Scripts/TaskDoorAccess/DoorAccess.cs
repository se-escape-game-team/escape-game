using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DoorAccess : MonoBehaviour
{
    public GameObject doorAccess;
    [SerializeField] private Color red = new Color(255, 0, 0);
    [SerializeField] private Color orange = new Color(191, 146, 0);
    [SerializeField] private Color green = new Color(16, 255, 0);


    // Start is called before the first frame update
    void Start()
    {
        Material acessMaterial = doorAccess.GetComponent<MeshRenderer>().material;
        if (SaveScript.doorIsOpen == false && SaveScript.HangmanWon == false)
        {
            // Farbe rot einstellen
            acessMaterial.SetColor("_EmissionColor", red);
        }
        else if (SaveScript.doorIsOpen == false && SaveScript.HangmanWon == true)
        {
            // Farbe orange einstellen
            acessMaterial.SetColor("_EmissionColor", orange);
        }
        else if (SaveScript.doorIsOpen == true && SaveScript.HangmanWon == true)
        {
            // Farbe gruen einstellen
            acessMaterial.SetColor("_EmissionColor", green);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
