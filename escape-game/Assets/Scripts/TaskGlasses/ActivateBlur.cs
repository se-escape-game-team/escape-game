using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlur : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<SnapshotMode>().enabled = !SaveScript.GlassesCollected;
    }
}
