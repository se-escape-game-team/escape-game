using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject))
        {
            GameObject hitGameObject = hitObject.transform.gameObject;
            if (hitGameObject.name == "DoorAccess" && ClickInventoryItem.SelectedItemSprite== "KeyCard")
            {
                // Tuer oeffnen
                Debug.Log("Open Door");
                SaveScript.DoorIsOpen = true;
            }
        }
    }
}
