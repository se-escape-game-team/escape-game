using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlinkingLightScript : MonoBehaviour
{
    private System.Diagnostics.Stopwatch stopwatch;
    private System.Diagnostics.Stopwatch redLightStopwatch;
    private bool lightIsRed;
    private Color lightColor;

    [SerializeField] Light[] lights;

    // Start is called before the first frame update
    void Start()
    {
        stopwatch.Start();
        lightIsRed = false;
        lightColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopwatch.Elapsed.Seconds >= 60)
        {
            lightIsRed = true;
            redLightStopwatch.Start();
            stopwatch.Restart();
        }
        else if (lightIsRed)
        {
            if (redLightStopwatch.ElapsedMilliseconds < 1000)
            {
                lightColor = Color.red;
            }
            else
            {
                lightIsRed = false;
                redLightStopwatch.Reset();
                lightColor = Color.white;
            }

            SetLightColour();
        }
    }

    private void SetLightColour()
    {
        foreach (Light light in lights)
        {
            light.color = lightColor;
        }
    }
}
