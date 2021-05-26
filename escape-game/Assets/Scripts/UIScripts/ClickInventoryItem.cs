using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ClickInventoryItem : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Color colorInventory = new Color(255, 255, 255);
    private Outline recentOutline;
    GameObject currentHover;



    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    void OnPointerEnter(PointerEventData eventData)
    //    {
    //        if (eventData.pointerCurrentRaycast.gameObject != null)
    //        {
    //            Debug.Log("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.name);
    //            currentHover = eventData.pointerCurrentRaycast.gameObject;
    //        }
    //    }

    //    void OnPointerExit(PointerEventData eventData)
    //    {
    //        currentHover = null;
    //    }


    //    if (currentHover)
    //    {
    //        Debug.Log(currentHover.name);
    //    }
    //    recentoutline = currentHover.getcomponent<outline>();
    //    recentoutline.outlinecolor = colorInventory;
    //    recentoutline.outlinewidth = outlinewidth;
    //    recentoutline.enabled = true;
    //    //washit = true;
    //}


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

