using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayHangman : MonoBehaviour
{
    [SerializeField] private Sprite[] hangmanStates;
    [SerializeField] private Image hangmanImage;
    [SerializeField] private Text hangmanWord;
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject nextWordButton;
    [SerializeField] private Text nextWordButtonText;
    [SerializeField] private Text roundText;
    [SerializeField] private int rounds;

    // Array mit allen zur Auswahl stehenden Worten
    private string[] words = { "Atmosphaere", "Marsmission", "Ich bin dumm", "Solarzelle", "Roboter", "Quantencomputer", "Raumanzug", "Satellit", "NASA", "Raumschiff", "Landekapsel", "WLAN", "SpaceX", "Software Engineering", "Escape Game" };

    private int mistakes = 0;
    private int currentRound = 0;
    
    private bool newRound = true;
    private bool sucess = true;
    private bool play = true;

    private string currentWord;
    private char[] hiddenWord;

    /// <summary>
    /// Setzt das Spiel komplett zur�ck
    /// </summary>
    public void ResetHangman()
    {
        mistakes = 0;
        currentRound = 0;
        hangmanImage.sprite = hangmanStates[0];
        nextWordButtonText.text = "Naechstes Wort";
    }

    private void Update()
    {
        // Wird nur ausgefuehrt wenn eine neue Runde gestartet werden soll
        if (newRound)
        {
            // Setzt alle f�r die naechste Runde benoetigten Komponenten zurueck
            roundText.text = $"Round {currentRound + 1}/{rounds}";
            currentWord = ChoseWord();
            Debug.Log(currentWord);
            hiddenWord = HideWord(currentWord);
            hangmanWord.text = new string(hiddenWord);
            newRound = false;
        }

        if (inputField.text != "" && inputField.text != null && play)
        {
            // Ueberprueft ob der eingegebene Buchstabe richtig ist
            if (CheckChar(inputField.text[0]))
            {
                hangmanWord.text = new string(hiddenWord);
            }
            else
            {
                mistakes++;
                hangmanImage.sprite = hangmanStates[mistakes];
            }
            inputField.text = "";

            // Ueberprueft ob das Wort erraten oder alle Versuche aufgebraucht wurden
            string hiddenWordString = new string(hiddenWord);
            if (hiddenWordString == currentWord)
            {
                Sucess();
            }
            else if (hangmanStates.Length - 1 == mistakes)
            {
                NoSucess();
            }
        }

        // Falls gerade nicht gespielt wird (Neue Runde Button aktiv) wird das Eingabefeld automatisch immer geleert
        if (!play)
        {
            inputField.text = "";
        }
    }

    /// <summary>
    /// Wird aufgerufen wenn alle Versuche das Wort zu loesen aufgebraucht sind. Dann wird das Hangman-Spiel neu gestartet.
    /// </summary>
    private void NoSucess()
    {
        sucess = false;
        play = false;
        nextWordButtonText.text = "Neues Spiel starten";
        nextWordButton.SetActive(true);
    }

    /// <summary>
    /// Wird aufgerufen wenn das Wort erraten wurde. Dann wird eine neue Runde gestartet.
    /// </summary>
    private void Sucess()
    {
        sucess = true;
        play = false;
        currentRound++;

        // Ueberpruefung ob alle Runden durchgespielt wurden
        if (currentRound == rounds)
        {
            roundText.text = "Du hast gewonnen!";
            SaveScript.HangmanWon = true;
        }
        else
        {
            nextWordButton.SetActive(true);
        }
    }

    /// <summary>
    /// Methode f�r NextRoundButton, startet die neue Runde.
    /// </summary>
    public void NextRound()
    {
        // Falls in dieser Runde das Wort nicht erraten wurde wird das Spiel auf Runde 1 zurueckgesetzt
        if (!sucess)
        {
            ResetHangman();
        }
        inputField.text = "";
        play = true;
        newRound = true;
        nextWordButton.SetActive(false);
    }

    /// <summary>
    /// �berpr�ft ob der eingegebene Character im Wort vorhanden ist und setzt diesen im HiddenWord ein.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool CheckChar(char c)
    {
        bool correct = false;
        for (int i = 0; i < currentWord.Length; i++)
        {
            if (Char.ToUpper(c) == Char.ToUpper(currentWord[i]))
            {
                hiddenWord[i] = currentWord[i];
                correct = true;
            }
        }
        return correct;
    }

    /// <summary>
    /// Sucht zufaellig ein neues Wort aus.
    /// </summary>
    /// <returns></returns>
    private string ChoseWord()
    {
        System.Random random = new System.Random();
        return words[random.Next(0, words.Length)];
    }

    /// <summary>
    /// Versteckt alle Buchstaben des Wortes und wei�t sie HiddenWord zu.
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    private char[] HideWord(string word)
    {
        char[] hiddenWord = new char[currentWord.Length];
        for (int i = 0; i < hiddenWord.Length; i++)
        {
            if (currentWord[i] == ' ')
            {
                hiddenWord[i] = ' ';
            }
            else
            {
                hiddenWord[i] = '-';
            }
        }
        return hiddenWord;
    }
}