using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // Saves the UI Slots for displaying the items
    public GameObject[] itemPanel;
    private Image[] itemImage;

    // List that saves all the collected item Sprites
    ArrayList itemList = new ArrayList();

    void Start()
    {
        // Getting the Image-Object childs of the panels
        itemImage = new Image[itemPanel.Length];
        for (int i = 0; i < itemPanel.Length; i++)
        {
            itemImage[i] = itemPanel[i].transform.Find($"ItemImage{i + 1}").GetComponent<Image>();
        }

        // Disables all the item-slots
        foreach (GameObject gameObject in itemPanel)
        {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Adds a new Item (Sprite) to the inventory. 
    /// </summary>
    /// <param name="sprite"></param>
    public void AddItem(Sprite sprite)
    {
        itemList.Add(sprite);
        //Debug.Log(itemList.Count);
        RefreshInventory();
    }

    void RefreshInventory()
    {
        //Debug.Log($"ItemList: {itemList.Count}\nItemImage: {itemImage.Length}\nItemPanel: {itemPanel.Length}");
        int panel = 0;
        for (int i = itemList.Count; i > itemList.Count - itemPanel.Length && i > 0; i--, panel++)
        {
            //Debug.Log($"Panel: {panel}\ni: {i}");
            itemPanel[panel].SetActive(true);
            itemImage[panel].sprite = (Sprite)itemList[i-1];
        }
    }
}
