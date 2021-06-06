using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScript
{
    // Speicher fuer Spielerposition
    private static Vector3 playerPosition = new Vector3(2,2,-11);
    public static Vector3 PlayerPosition
    {
        get => playerPosition;
        set => playerPosition = value;
    }

    // Speicher fuer Lockscreen
    private static string username = "user";
    public static string Username
    {
        get => username;
        set => username = value;
    }

    private static int tries = 0;
    public static int Tries
    {
        get => tries;
        set => tries = value;
    }

    private static bool hintShown = false;
    public static bool HintShown
    {
        get => hintShown;
        set => hintShown = value;
    }


    // Weiteres Zeug
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


    /// <summary>
    /// Gibt an, ob die Brille schon eigesammelt wurde.
    /// </summary>
    private static bool glassesCollected = false;

    public static bool GlassesCollected
    {
        get => glassesCollected;
        set => glassesCollected = value;
    }


    private static bool hangmanWon = false;
    public static bool HangmanWon
    {
        get => hangmanWon;
        set => hangmanWon = value;
    }


    public static bool doorIsOpen = false;
    public static bool DoorIsOpen
    {
        get => doorIsOpen;
        set => doorIsOpen = value;
    }
}
