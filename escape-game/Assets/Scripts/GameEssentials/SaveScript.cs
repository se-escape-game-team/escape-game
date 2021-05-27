using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    private static bool inLabScene = true;

    public static bool InLabScene
    {
        get => inLabScene;
        set => inLabScene = value;
    }

    private static bool startMessageWasShown = false;

    public static bool StartMessageWasShown
    {
        get => startMessageWasShown;
        set => startMessageWasShown = value;
    }
}
