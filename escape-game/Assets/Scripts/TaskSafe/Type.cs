using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Type : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private string password;
    [SerializeField] private MeshRenderer lightOk;

    //private float time = 0.5f;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject) && !SaveScript.pause)
        {
            GameObject hitGameObject = hitObject.transform.gameObject;
            if (hitGameObject.tag == "Selectable")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hitGameObject.transform.GetChild(0).name == "Enter")
                    {
                        if (CheckPassword())
                        {
                            lightOk.material.color = Color.green;
                            SaveScript.safeOpen = true;
                        }
                        else
                        {
                            // Resets DisplayText
                            text.text = "";
                        }

                    }
                    else if (hitGameObject.transform.GetChild(0).name == "Delete")
                    {
                        text.text = DeleteLastCharacter(text.text);
                    }
                    else
                    {
                        if (text.text.Length < 6)
                        {
                            text.text += hitGameObject.transform.GetChild(0).name;
                        }
                    }
                }
            }
        }
    }

    private string DeleteLastCharacter(string s)
    {
        string temp = "";
        for (int i = 0; i < text.text.Length - 1; i++)
        {
            temp += text.text[i];
        }
        return temp;
    }

    private bool CheckPassword()
    {
        if (text.text.Length != password.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != text.text[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
