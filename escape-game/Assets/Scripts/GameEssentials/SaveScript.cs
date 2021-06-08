using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class SaveScript
{
    // Speicher fuer Spielerposition
    private static Vector3 playerPosition = new Vector3(2,2,-11);
    public static Vector3 PlayerPosition
    {
        get => playerPosition;
        set => playerPosition = value;
    }

    // Speicher fuer Rotation der Kamera
    private static float camerRotationX = 0f;
    public static float CamerRotationX
    {
        get => camerRotationX;
        set => camerRotationX = value;
    }

    // Speichert fuer Rotation des Spielers
    private static float playerRotationY = 3f;
    public static float PlayerRotationY
    {
        get => playerRotationY;
        set => playerRotationY = value;
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

    /// <summary>
    /// Gibt an, ob das Pause Menue an ist
    /// </summary>
    public static bool pause = false;


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

    /// <summary>
    /// Speicher fuer die Panel-Objekte im Inventar UI
    /// </summary>
    public static GameObject[] itemPanel;

    /// <summary>
    /// Speicher fuer die Image-Objekte im Inventar UI
    /// </summary>
    public static Image[] itemImage;

    /// <summary>
    /// Speicher fuer die Arrows des Inventars. 0 ist up, 1 ist down.
    /// </summary>
    public static Image[] inventoryArrows;

    /// <summary>
    /// Speicher fuer die Sprites im Inventar
    /// </summary>
    public static ArrayList itemList = new ArrayList();

    /// <summary>
    /// Speicher fuer das aktuelle Sprite in itemList, das im Inventar ganz oben angezeigt wird
    /// </summary>
    public static int currentItem0Position = 0;

    /// <summary>
    /// Speichert die noch übrige Zeit in Sekunden
    /// </summary>
    public static float secondsLeft;

    private static string name = Username;
    public static string Name
    {
        get => name;
        set => name = value;
    }
}
