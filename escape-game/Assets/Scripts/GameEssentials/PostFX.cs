using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostFX : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;
    private ColorGrading colorGrading;

    bool up;
    float duration = 15;

    void Start()
    {
        postProcessVolume = gameObject.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }

    void Update()
    {
        if (SaveScript.lsdActivated)
        {
            duration -= Time.deltaTime;
            if (colorGrading.hueShift.value >= 180f)
            {
                up = false;
            }
            else if (colorGrading.hueShift.value <= -180f)
            {
                up = true;
            }

            if (up)
            {
                colorGrading.hueShift.value = colorGrading.hueShift.value + (70 * Time.deltaTime);
            }
            else
            {
                colorGrading.hueShift.value = colorGrading.hueShift.value - (70 * Time.deltaTime);
            }

            if(duration < 0)
            {
                SaveScript.lsdActivated = false;
                colorGrading.hueShift.value = 0;
                duration = 15;
            }
        }
    }
}
