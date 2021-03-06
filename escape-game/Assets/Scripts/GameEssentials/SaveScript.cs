using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class SaveScript
{
    /// <summary>
    /// Speichert die Position des Spielers (wird immer beim verlassen der Lab-Scene aktualisiert)
    /// </summary>
    public static Vector3 playerPosition = new Vector3(-1.2f, 2.6f, -1.9f);

    /// <summary>
    /// Speichert die Rotation des Spielers (wird immer beim verlassen der Lab-Scene aktualisiert)
    /// </summary>
    public static float playerRotationY = 3f;

    /// <summary>
    /// Speichert die Rotation der Spieler-Kamera (wird immer beim verlassen der Lab-Scene aktualisiert)
    /// </summary>
    public static float camerRotationX = 0f;

    /// <summary>
    /// Speicher fuer im Startmenue festgelegten Namen
    /// </summary>
    public static string username = "user";

    /// <summary>
    /// Speicher fuer die benoetigten Versuche zum Entsperren des Computers
    /// </summary>
    public static int tries = 0;

    /// <summary>
    /// Speichert ob der Tipp zum Herausfinden des Passworts fuer den PC angezeigt wurde
    /// </summary>
    public static bool hintShown = false;

    /// <summary>
    /// Gibt an ob das Pause Menue an ist
    /// </summary>
    public static bool pause = false;

    /// <summary>
    /// Gibt an ob die Startnachricht angezeigt wurde 
    /// </summary>
    public static bool startMessageWasShown = false;

    /// <summary>
    /// Gibt an ob der Hinweis zu der Brille schon gegeben wurde
    /// </summary>
    public static bool glassesHintWasShown = false;

    /// <summary>
    /// Gibt an ob die Brille schon eigesammelt wurde.
    /// </summary>
    public static bool glassesCollected = false;

    /// <summary>
    /// Gibt an ob die Medizin genommen wurde
    /// </summary>
    public static bool lsdMode = false;

    /// <summary>
    /// Gibt an ob das Hangman-Minispiel gewonnen wurde
    /// </summary>
    public static bool hangmanWon = false;

    /// <summary>
    /// Gibt an ob der Browser geoeffnet wurde
    /// </summary>
    public static bool browserOpen = false;

    /// <summary>
    /// Gibt an ob der Safe entsperrt wurde
    /// </summary>
    public static bool safeOpen = false;

    /// <summary>
    /// Gibt an ob die Tuer geoeffnet wurde (also mit Karte entriegelt)
    /// </summary>
    public static bool doorIsOpen = false;

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
    /// Speichert die noch ?brige Zeit in Sekunden
    /// </summary>
    public static float secondsLeft = 30;

    /// <summary>
    /// Gibt an, wie viel Zeit man insgesamt hat um aus dem Labor zu entkommen
    /// </summary>
    public static float totalTime = 30;

    /// <summary>
    /// Gibt an ob die Zeit des Timers schon gesetzt wurde
    /// </summary>
    public static bool timeSet = false;

    /// <summary>
    /// Speichert ob der Spieler nach verlieren des Spiels weiterspielen will
    /// </summary>
    public static bool continueAfterDefeat = false;

    /// <summary>
    /// Speichert an welche Buchstaben sichtbar sind
    /// </summary>
    public static bool[] letterVisible = new bool[18];
}