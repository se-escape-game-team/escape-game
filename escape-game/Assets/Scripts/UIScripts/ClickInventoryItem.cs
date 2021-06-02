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
    string currentItem;
    PointerEventData eventDat;
    bool moveItem = false;
    Image itemImage;
    Vector3 recentPosition;

    void Update()
    {
        if (itemImage)
        {
            DragItem();
        }

        if (currentHover && currentHover.transform.tag == "Selectable - InventoryItem" && !moveItem)
        {
            
            GameObject hitObject = currentHover.gameObject;
            
            if (currentHover.name.Length == 5)
            {
                itemImage = transform.Find($"ItemImage{hitObject.name[4]}").GetComponent<Image>();
                Debug.Log(itemImage.sprite.name + "hskjhdksjhd");
            }
            else if (currentHover.name.Length == 10)
            {
                itemImage = currentHover.GetComponent<Image>();
                Debug.Log("ghjgjhg");
            }
            else
            {
                throw new Exception("Fehler weil Name von Inventory falsch.");
            }

            if(Input.GetMouseButton(0))
            {
                recentPosition = itemImage.transform.position;
                moveItem = true;
            }
        }
        else
        {
            currentHover = null;    
        }
    }

    private void DragItem()
    {
        if (moveItem && Input.GetMouseButton(0))
        {
            itemImage.transform.position = Input.mousePosition;
        }
        else
        {
            itemImage.transform.position = recentPosition;
            moveItem = false;
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

