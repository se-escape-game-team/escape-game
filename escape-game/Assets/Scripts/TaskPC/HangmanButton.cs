using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HangmanButton : MonoBehaviour
{
    public void OpenHangmanApplication()
    {
        gameObject.SetActive(true);
    }

    public void CloseHangmanApplication()
    {
        gameObject.SetActive(false);
    }
}
