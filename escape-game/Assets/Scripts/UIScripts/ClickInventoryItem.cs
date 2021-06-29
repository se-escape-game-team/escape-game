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
    Image itemImage = null;
    Vector3 recentPosition;

    private static string selectedItemSprite = "";
    public static string SelectedItemSprite => selectedItemSprite;

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
                }
                // Zeiger ueber Item-Image
                else if (currentHover.name.Length == 10)
                {
                    itemImage = currentHover.GetComponent<Image>();
                }
                else
                {
                    throw new Exception("Fehler weil Name von Inventory falsch.");
                }
                // Speichern der ursprueglichen Position des Items im Inventar
                recentPosition = itemImage.transform.position;
                // Vergroeﬂern des Items ums dreifache
                itemImage.transform.localScale = new Vector3(3, 3);
                // Freischalten der DragItem-Methode
                dragItem = true;
            }
        }
    }

    /// <summary>
    /// Methode dass das Item dem Mauszeiger waehrend dem Klicken folgt
    /// </summary>
    private void DragItem()
    {
        if (dragItem && Input.GetMouseButton(0))
        {
            // Item folgt der Maus
            itemImage.transform.position = Input.mousePosition;
            selectedItemSprite = itemImage.sprite.name;
        }
        else
        {
            // Falls die Maustaste losgelassen wird, wird das Item wieder zurueck ins Inventar an seine uerspruengliche Stelle gelegt
            itemImage.transform.position = recentPosition;
            // Groeﬂe auf Standart zuruecksetzen
            itemImage.transform.localScale = new Vector3(1, 1);
            selectedItemSprite = "";
            itemImage = null;
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
            currentHover = eventData.pointerCurrentRaycast.gameObject;
        }
    }

    /// <summary>
    /// setzt currentHover zurueck, wenn die Maus ueber keinem Objekt ist
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        currentHover = null;
    }
}

