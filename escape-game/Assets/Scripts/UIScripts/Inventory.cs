using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image arrowUp;
    [SerializeField] private Image arrowDown;

    // Saves the UI Slots for displaying the items
    public GameObject[] itemPanel;
    private Image[] itemImage;

    //bool test = true;

    // List that saves all the collected item Sprites
    ArrayList itemList = new ArrayList();

    int currentItem0Position = 0;

    void Start()
    {
        // Getting the Image-Object childs of the panels
        itemImage = new Image[itemPanel.Length];
        for (int i = 0; i < itemPanel.Length; i++)
        {
            itemImage[i] = itemPanel[i].transform.Find($"ItemImage{i}").GetComponent<Image>();
        }

        // Disables all the item-slots
        foreach (GameObject gameObject in itemPanel)
        {
            gameObject.SetActive(false);
        }

        //Disable arrows
        arrowDown.enabled = false;
        arrowUp.enabled = false;
    }

    private void Update()
    {
        if (itemList.Count > itemPanel.Length)
        {
            // Scroll up
            if (Input.GetAxis("MouseScrollWheel") > 0)
            {
                ScrollUp();
                RefreshInventory();
            }
            // Scroll down
            else if (Input.GetAxis("MouseScrollWheel") < 0)
            {
                ScrollDown();
                RefreshInventory();
            }





        }

        //zum Testen der DeleteIteme Methode mit der Leertaste
        //if (Input.GetAxis("Jump")!=0&&test)
        //{
        //    DeleteItem((Sprite)itemList[0]);
        //    test = false;
        //}
        //if (Input.GetAxis("Jump") == 0)
        //{
        //    test = true;
        //}

    }

    /// <summary>
    /// Element view goes up
    /// </summary>
    void ScrollDown()
    {
        if (currentItem0Position >= itemImage.Length)
        {
            currentItem0Position--;
        }
    }

    /// <summary>
    /// Element view goes down
    /// </summary>
    void ScrollUp()
    {
        if (currentItem0Position < itemList.Count - 1)
        {
            currentItem0Position++;
        }
    }

    /// <summary>
    /// Adds a new Item (Sprite) to the inventory. 
    /// </summary>
    /// <param name="sprite"></param>
    public void AddItem(Sprite sprite)
    {
        itemList.Add(sprite);
        currentItem0Position = itemList.Count - 1;
        //Debug.Log($"Current Position: {currentItem0Position}");
        //Debug.Log(itemList.Count);
        RefreshInventory();
    }
    /// <summary>
    /// Delets Sprite out of ItemList of Inventory
    /// </summary>
    /// <param name="sprite">Sprite to delete</param>
    public void DeleteItem(Sprite sprite)
    {
        itemList.Remove(sprite);
        currentItem0Position = itemList.Count - 1;
        RefreshInventory();
    }

    void RefreshInventory()
    {
        //Debug.Log($"ItemList: {itemList.Count}\nItemImage: {itemImage.Length}\nItemPanel: {itemPanel.Length}");
        if (itemList.Count <= itemImage.Length)
        {
            foreach (GameObject g in itemPanel)
            {
                g.SetActive(false);
            }
            int panel = 0;
            for (int i = currentItem0Position; i >= 0; i--, panel++)
            {
                itemPanel[panel].SetActive(true);
                itemImage[panel].sprite = (Sprite)itemList[i];
            }
        }
        else
        {
            int panel = 0;
            for (int i = currentItem0Position; i > currentItem0Position - itemImage.Length; i--, panel++)
            {
                itemImage[panel].sprite = (Sprite)itemList[i];
            }

            // Check to enable Arrow Up
            if (currentItem0Position < itemList.Count - 1)
            {
                arrowUp.enabled = true;
            }
            else
            {
                arrowUp.enabled = false;
            }

            // Check to enable Arrow Down
            if (currentItem0Position >= itemImage.Length)
            {
                arrowDown.enabled = true;
            }
            else
            {
                arrowDown.enabled = false;
            }
        }
    }

    //public bool TakeItem()
    //{
    //    public static bool IsPointerOverUIObject()
    //    {
    //        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    //        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //        List<RaycastResult> results = new List<RaycastResult>();
    //        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    //        return results.Count > 0;
    //    }



    //    wasHit = false;
    //    if (Physics.Raycast(ray, out raycastHit, distance))
    //    {
    //        GameObject hitObject = raycastHit.collider.gameObject;
    //        if (hitObject.tag == "Selectable - Item")
    //        {
    //            // Apply outline for item
    //            recentOutline = hitObject.GetComponent<Outline>();
    //            recentOutline.OutlineColor = colorItems;
    //            recentOutline.OutlineWidth = outlineWidth;
    //            recentOutline.enabled = true;
    //            wasHit = true;

    //            if (Input.GetMouseButtonDown(0))
    //            {
    //                // Adds Item to inventory (with sprite saved in ObjectImage.cs)
    //                inventory.AddItem(hitObject.GetComponent<ObjectImage>().inventoryImage);
    //                Destroy(hitObject);
    //            }
    //        }
    //    }
    //}
}
