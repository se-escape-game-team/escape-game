using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePaper : MonoBehaviour
{
    [SerializeField] GameObject[] papers = new GameObject[3];
    int activePaper = -1;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;
        if (Physics.Raycast(ray, out hitObject) && !SaveScript.pause)
        {
            GameObject hitGameObject = hitObject.transform.gameObject;
            if (hitGameObject.name == "SpotPapersTrigger" && ClickInventoryItem.SelectedItemSprite.Contains("Paper"))
            {
                SetPaperActive(ClickInventoryItem.SelectedItemSprite[5] - 48);
            }
        }
    }

    private void SetPaperActive(int paper)
    {
        // Falls schon ein Papier aktiv ist soll es erst deaktiviert werden bevor ein neues aktiviert wird
        if (activePaper != -1)
        {
            papers[activePaper].SetActive(false);
        }
        papers[paper].SetActive(true);
        activePaper = paper;
    }
}
