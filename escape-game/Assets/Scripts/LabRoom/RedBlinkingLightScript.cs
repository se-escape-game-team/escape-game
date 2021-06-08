using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RedBlinkingLightScript //: MonoBehaviour
{
    private static readonly System.Diagnostics.Stopwatch stopwatchLighting;
    private static readonly System.Diagnostics.Stopwatch redLightStopwatch;
    private static bool lightIsRed;
    private static Color lightColor;

    static ArrayList lightsWithTag = new ArrayList();

    //[SerializeField] Light[] lights;

    //private Light[] lights;

    // Start is called before the first frame update
    static void Start()
    {
        Light[] allLights = GameObject.FindObjectsOfType<Light>();

        foreach (Light light in allLights)
        {
            if (light.tag == "BlinkingLight")
            {
                lightsWithTag.Add(light);
            }
        }




        stopwatchLighting.Start();
        lightIsRed = false;
        lightColor = Color.white;
    }

    // Update is called once per frame
    static void Update()
    {
        if (stopwatchLighting.Elapsed.Seconds >= 5)
        {
            lightIsRed = true;
            redLightStopwatch.Start();
            stopwatchLighting.Restart();
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

    private static void SetLightColour()
    {
        foreach (Light light in lightsWithTag)
        {
            light.color = lightColor;
        }
    }
}
