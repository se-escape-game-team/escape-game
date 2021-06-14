using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorShift : MonoBehaviour
{
    private ColorGrading colorGrading;
    bool up = true;

    public void Start()
    {
        PostProcessVolume postFX = gameObject.GetComponent<PostProcessVolume>();
        postFX.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (colorGrading.hueShift.value >= 180)
        {
            up = false;
        }
        else if (colorGrading.hueShift.value <= 180)
        {
            up = true;
        }

        if (up)
        {
            colorGrading.hueShift.value++;
        }
        else
        {
            colorGrading.hueShift.value--;
        }
    }
}
