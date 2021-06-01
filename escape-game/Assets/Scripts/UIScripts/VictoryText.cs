using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryText : MonoBehaviour
{
    public Text textArea;
    private string output;   

    // Update is called once per frame
    void Update()
    {
        output = "";
        output += "Hallo xy, Deine verbleibende Zeit: \n";
        output += Timer.timeLeft;
        textArea.text = output;
    }
}

