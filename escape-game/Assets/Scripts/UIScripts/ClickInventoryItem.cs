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






    //if (Input.GetMouseButtonDown(0) == true && EventSystem.current.IsPointerOverGameObject())
    //{
    //    Debug.Log(EventSystem.current.currentSelectedGameObject.gameObject.name);
    //}

    //if (EventSystem.current.IsPointerOverGameObject())
    //{
    //    Debug.Log(GameObjectUnderPointer());

    //    //recentOutline = hitObject.GetComponent<Outline>();
    //    //recentOutline.OutlineColor = colorTasks;
    //    //recentOutline.OutlineWidth = outlineWidth;
    //    //recentOutline.enabled = true;
    //    //wasHit = true;
    //}

    //if (EventSystem.current.IsPointerOverGameObject())
    //{
    //    //Debug.Log("Its over UI elements");
    //    if (EventSystem.current != null)
    //    {
    //        //Debug.Log("Current Objekt != null");


    //    }
    //    if (EventSystem.current.CompareTag("Selectable - InventoryItem"))
    //    {
    //        Debug.Log("Tagged Selectable");
    //    }

    //}



    //if (EventSystem.current.IsPointerOverGameObject())
    //{
    //    Debug.Log("Its over UI elements");

    //}
    //else
    //{
    //    Debug.Log("Its NOT over UI elements");
    //}
}

