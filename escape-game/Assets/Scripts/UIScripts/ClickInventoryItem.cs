using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ClickInventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color colorInventory = new Color(255, 255, 0);
    [SerializeField] private int outlineWidth = 10;
    private Outline recentOutline;
    bool wasHit = false;

    GameObject currentHover;
    string currentItem;
    PointerEventData eventDat;



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (currentHover)
        {
            GameObject hitObject = currentHover.gameObject;

            //Debug.Log(currentHover.name + " @ " + Input.mousePosition);
            currentItem = hitObject.name;

            recentOutline = hitObject.GetComponent<Outline>();
            recentOutline.OutlineColor = colorInventory;
            recentOutline.OutlineWidth = outlineWidth;
            recentOutline.enabled = true;
            Debug.Log(currentItem);
            wasHit = true;
        }
        else
        {
            currentHover = null;
        }

        //// Reset outline
        //if (!wasHit && recentOutline != null)
        //{
        //    recentOutline.enabled = false;
        //    recentOutline = null;
        //    wasHit = false;
        //}
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
    /// setzt currentHover zurück, wenn die Maus über keinem Objekt ist
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

