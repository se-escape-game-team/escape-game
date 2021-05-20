using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Type : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private string password;
    [SerializeField] private MeshRenderer light;

    private bool startTimer;
    private float time = 2;

    void Update()
    {
        if (startTimer)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                ChangeScene.ChangeSceneBackToLab();
            }
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject))
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
                            light.material.color = Color.green;
                            startTimer = true;
                        }
                        else
                        {
                            text.text = "";
                        }
                        
                    }
                    else if (hitGameObject.transform.GetChild(0).name == "Delete")
                    {
                        string temp = "";
                        for(int i = 0; i < text.text.Length-1; i++)
                        {
                            temp += text.text[i];
                        }
                        text.text = temp;
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
