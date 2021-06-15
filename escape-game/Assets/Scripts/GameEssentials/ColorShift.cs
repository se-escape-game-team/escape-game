using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorShift : MonoBehaviour
{
    private ColorGrading colorGrading;
    bool up = true;
    private float duration = 15;

    public void Start()
    {
        PostProcessVolume postFX = gameObject.GetComponent<PostProcessVolume>();
        postFX.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (SaveScript.lsdMode)
        {
            duration -= Time.deltaTime;
            if (colorGrading.hueShift.value >= 180)
            {
                up = false;
            }
            else if (colorGrading.hueShift.value <= -180)
            {
                up = true;
            }

            if (up)
            {
                colorGrading.hueShift.value = colorGrading.hueShift.value + (75 * Time.deltaTime);
            }
            else
            {
                colorGrading.hueShift.value = colorGrading.hueShift.value - (75 * Time.deltaTime);
            }

            if (duration <= 0)
            {
                duration = 15;
                colorGrading.hueShift.value = 0;
                SaveScript.lsdMode = false;
            }
        }
    }
}
