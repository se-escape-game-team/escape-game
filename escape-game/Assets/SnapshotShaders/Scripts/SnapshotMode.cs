using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class SnapshotMode : MonoBehaviour
{
    [SerializeField]
    private bool useCanvas = true;

    [SerializeField]
    private SnapshotCanvas snapshotCanvasPrefab;

    private SnapshotCanvas snapshotCanvas;
    
    private Shader gaussianShader;
    Shader noneShader;
    

    List<SnapshotFilter> filters = new List<SnapshotFilter>();

    int filterIndex = 0;
    bool isBlurred;

    private void Awake()
    {
        // Add a canvas to show the current filter name and the controls.
        if (useCanvas)
        {
            snapshotCanvas = Instantiate(snapshotCanvasPrefab);
        }

        // Find all shader files.        
        gaussianShader = Shader.Find("Snapshot/GaussianBlur");        

        // Create all filters.       
        filters.Add(new BlurFilter("Blur (Full)", Color.white, gaussianShader));
        filters.Add(new BlurFilter("Blur (None)", Color.white, noneShader));
    }

    private void Start()
    {
        snapshotCanvas.SetFilterProperties(new BlurFilter("Blur (Full)", Color.white, gaussianShader));
        isBlurred = true;
    }

    private void Update()
    {
        if(isBlurred)
        {
            snapshotCanvas.SetFilterProperties(new BlurFilter("Blur (None)", Color.white, noneShader));
        }
    }

    // Delegate OnRenderImage() to a SnapshotFilter object.
    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        filters[filterIndex].OnRenderImage(src, dst);
    }
}
