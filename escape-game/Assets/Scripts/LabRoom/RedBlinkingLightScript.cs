using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlinkingLightScript : MonoBehaviour
{
    private bool lightIsRed;
    private Color lightColor;

    List<Light> lights = new List<Light>();
    List<Material> lamps = new List<Material>();

    void Start()
    {
        GameObject[] blinkingLights = GameObject.FindGameObjectsWithTag("BlinkingLight");
        foreach(GameObject g in blinkingLights)
        {
            MeshRenderer mr;
            if(g.TryGetComponent<MeshRenderer>(out mr))
            {
                lamps.Add(mr.material);
            }
            else
            {
                lights.Add(g.GetComponent<Light>());
            }
        }

        lightIsRed = false;
        lightColor = Color.white;
    }

    float timer = -1;
    void Update()
    {
        if ((SaveScript.secondsLeft % 4) <= 0.1 && timer < 0)
        {
            lightIsRed = true;
            timer = 1;
        }
        else if (lightIsRed)
        {
            timer -= Time.deltaTime;
            if (timer > 0)
            {
                lightColor = Color.red;
            }
            else
            {
                lightIsRed = false;
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
        foreach(Material material in lamps)
        {
            material.SetColor("_EmissionColor", lightColor);
        }
    }
}
