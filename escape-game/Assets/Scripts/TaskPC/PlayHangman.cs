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
    [SerializeField] private int rounds;
    [SerializeField] private string[] words = { "Atmosphäre", "Marsmission", "IchBinDumm", "Solarzelle" };


    private int mistakes = 0;
    private int currentRound = 0;
    private bool newRound = true;

    private string currentWord;
    private char[] hiddenWord;
    
    public void ResetHangman()
    {
        mistakes = 0;
        currentRound = 0;
        hangmanImage.sprite = hangmanStates[0];
    }

    private void Update()
    {
        if (newRound)
        {
            currentWord = ChoseWord();
            Debug.Log(currentWord);
            hiddenWord = HideWord(currentWord);
            hangmanWord.text = new string(hiddenWord);
            newRound = false;
        }

        if(inputField.text != "" && inputField.text != null)
        {
            if (CheckChar(inputField.text[0]))
            {
                hangmanWord.text = new string(hiddenWord);
            }
            else {
                mistakes++;
                hangmanImage.sprite = hangmanStates[mistakes];
            }
            inputField.text = "";

            string hiddenWordString = new string(hiddenWord);
            if(hiddenWordString == currentWord)
            {
                Sucess();
            }
        }
    }

    private void Sucess()
    {
        currentRound++;

        if(currentRound == rounds)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log($"Round: {currentRound}");
            nextWordButton.SetActive(true);
            Debug.Log($"Show button");
        }
    }

    public void NextRound()
    {
        newRound = true;
        nextWordButton.SetActive(false);
    }


    private bool CheckChar(char c)
    {
        bool correct = false;
        for(int i = 0; i < currentWord.Length; i++)
        {
            if(Char.ToUpper(c) == Char.ToUpper(currentWord[i]))
            {
                hiddenWord[i] = currentWord[i];
                correct = true;
            }
        }
        return correct;
    }

    private string ChoseWord()
    {
        System.Random random = new System.Random();
        return words[random.Next(0, words.Length)];
    }

    private char[] HideWord(string word)
    {
        char[] hiddenWord = new char[currentWord.Length];
        for (int i = 0; i < hiddenWord.Length; i++)
        {
            hiddenWord[i] = '-';
        }
        return hiddenWord;
    }
}
