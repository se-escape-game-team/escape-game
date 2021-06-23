using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayHangmanTest
{
    [Test]
    public void HideWordTest()
    {
        // Arrange
        PlayHangman playHangman = new PlayHangman();
        string word1 = "Hangman";
        string word2 = "Play Hangman";

        // Act
        string word1Hidden = new string(playHangman.HideWord(word1));
        string word2Hidden = new string(playHangman.HideWord(word2));

        // Assert
        Assert.That(word1Hidden, Is.EqualTo("-------"));
        Assert.That(word2Hidden, Is.EqualTo("---- -------"));
    }

    [Test]
    public void CheckCharTest()
    {
        //// Arrange
        //PlayHangman playHangman = new PlayHangman();
        //string word1 = "Hangman";
        //char[] word1Hidden = "-------".ToCharArray();
        //string word2 = "Play Hangman";
        //char[] word2Hidden = "---- -------".ToCharArray();

        //// Act
        //playHangman.CheckChar('a', word1, ref word1Hidden);
        //playHangman.CheckChar('h', word1, ref word1Hidden);

        //playHangman.CheckChar('a', word2, ref word2Hidden);
        //playHangman.CheckChar('h', word2, ref word2Hidden);

        //// Assert
        //Assert.That(word1Hidden.ToString(), Is.EqualTo("Ha----a-"));
        //Assert.That(word2Hidden.ToString(), Is.EqualTo("--a- Ha----a-"));
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator PlayHangmanTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
