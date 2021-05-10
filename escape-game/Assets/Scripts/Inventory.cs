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
    }

    /// <summary>
    /// Element view goes up
    /// </summary>
    void ScrollDown()
    {
        if (currentItem0Position >= 3)
        {
            Debug.Log("Scroll down");
            currentItem0Position--;
            Debug.Log($"Current Position: {currentItem0Position}");
        }
    }

    /// <summary>
    /// Element view goes down
    /// </summary>
    void ScrollUp()
    {
        if (currentItem0Position < itemList.Count - 1)
        {
            Debug.Log("Scroll up");
            currentItem0Position++;
            Debug.Log($"Current Position: {currentItem0Position}");
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
        Debug.Log($"Current Position: {currentItem0Position}");
        //Debug.Log(itemList.Count);
        RefreshInventory();
    }

    void RefreshInventory()
    {
        //Debug.Log($"ItemList: {itemList.Count}\nItemImage: {itemImage.Length}\nItemPanel: {itemPanel.Length}");
        if (itemList.Count <= 3)
        {
            int panel = 0;
            for (int i = currentItem0Position; i >= 0; i--, panel++)
            {
                //Debug.Log($"i: {i}");
                itemPanel[panel].SetActive(true);
                itemImage[panel].sprite = (Sprite)itemList[i];
            }
        }
        else
        {
            int panel = 0;
            for (int i = currentItem0Position; i > currentItem0Position - 3; i--, panel++)
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
            if (currentItem0Position >= 3)
            {
                arrowDown.enabled = true;
            }
            else
            {
                arrowDown.enabled = false;
            }
        }
    }
}
