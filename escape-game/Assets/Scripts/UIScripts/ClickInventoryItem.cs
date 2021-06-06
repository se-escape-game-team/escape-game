using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject currentHover;
    bool dragItem = false;
    Image itemImage;
    Vector3 recentPosition;

    private static string selectedItem = "";

    /// <summary>
    /// Gibt den Namen des aktuell ausgewaehlten Item-Sprites zurueck.
    /// </summary>
    public static string SelctedItem => selectedItem;

    void Update()
    {
        if (itemImage)
        {
            DragItem();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (currentHover && currentHover.transform.tag == "Selectable - InventoryItem")
            {
                // Zeiger ueber Item-Panel
                if (currentHover.name.Length == 5)
                {
                    itemImage = currentHover.transform.Find($"ItemImage{currentHover.name[4]}").GetComponent<Image>();
                    // Debug.Log("Image über ItemPanel: " + itemImage.sprite.name);
                }
                // Zeiger ueber Item-Image
                else if (currentHover.name.Length == 10)
                {
                    itemImage = currentHover.GetComponent<Image>();
                    // Debug.Log("Image direkt über Image " + itemImage.sprite.name);
                }
                else
                {
                    throw new Exception("Fehler weil Name von Inventory falsch.");
                }
                // Speichern der ursprueglichen Position des Items im Inventar
                recentPosition = itemImage.transform.position;
                // Vergroeßern des Items ums dreifache
                itemImage.transform.localScale = new Vector3(3, 3);
                // Freischalten der DragItem-Methode
                dragItem = true;
            }
        }
    }

    private void DragItem()
    {
        if (dragItem && Input.GetMouseButton(0))
        {
            // Item folgt der Maus
            itemImage.transform.position = Input.mousePosition;
            selectedItem = itemImage.sprite.name;
        }
        else
        {
            // Falls die Maustaste losgelassen wird, wird das Item wieder zurueck ins Inventar an seine uerspruengliche Stelle gelegt
            itemImage.transform.position = recentPosition;
            // Groeße auf Standart zuruecksetzen
            itemImage.transform.localScale = new Vector3(1, 1);
            selectedItem = "";
            dragItem = false;
        }
    }


    /// <summary>
    /// Erkennt das aktuelle Objekt unter der Maus
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            Debug.Log("HOVER");
            currentHover = eventData.pointerCurrentRaycast.gameObject;
        }
    }
    /// <summary>
    /// setzt currentHover zur?ck, wenn die Maus ?ber keinem Objekt ist
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        currentHover = null;
    }
}

