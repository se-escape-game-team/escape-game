using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image arrowUp;
    [SerializeField] private Image arrowDown;

    // UI Elemente fuer Inventaranzeige
    public GameObject[] itemPanel;
    public Image[] itemImage;

    void Start()
    {
        // Speichern der UI Elemente
        SaveScript.itemPanel = itemPanel;
        SaveScript.itemImage = itemImage;
        SaveScript.inventoryArrows = new Image[]{arrowUp, arrowDown};
        
        // Deaktivieren der Item-Slots
        foreach (GameObject gameObject in SaveScript.itemPanel)
        {
            gameObject.SetActive(false);
        }

        // Deaktivieren der Pfeile
        SaveScript.inventoryArrows[0].enabled = false;
        SaveScript.inventoryArrows[1].enabled = false;
    }

    private void Update()
    {
        // Checken ob Scrollen moeglich ist
        if (SaveScript.itemList.Count > SaveScript.itemPanel.Length)
        {
            // Scrollen registrieren
            if (Input.GetAxis("MouseScrollWheel") > 0)
            {
                ScrollUp();
                RefreshInventory();
            }
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
        if (SaveScript.currentItem0Position >= SaveScript.itemImage.Length)
        {
            SaveScript.currentItem0Position--;
        }
    }

    /// <summary>
    /// Element view goes down
    /// </summary>
    void ScrollUp()
    {
        if (SaveScript.currentItem0Position < SaveScript.itemList.Count - 1)
        {
            SaveScript.currentItem0Position++;
        }
    }

    /// <summary>
    /// Adds a new Item (Sprite) to the inventory. 
    /// </summary>
    /// <param name="sprite"></param>
    public void AddItem(Sprite sprite)
    {
        SaveScript.itemList.Add(sprite);
        SaveScript.currentItem0Position = SaveScript.itemList.Count - 1;
        RefreshInventory();
    }

    /// <summary>
    /// Delets Sprite out of ItemList of Inventory
    /// </summary>
    /// <param name="sprite">Sprite to delete</param>
    public void DeleteItem(Sprite sprite)
    {
        SaveScript.itemList.Remove(sprite);
        SaveScript.currentItem0Position = SaveScript.itemList.Count - 1;
        RefreshInventory();
    }

    void RefreshInventory()
    {
        if (SaveScript.itemList.Count <= SaveScript.itemImage.Length)
        {
            foreach (GameObject g in SaveScript.itemPanel)
            {
                g.SetActive(false);
            }
            int panel = 0;
            for (int i = SaveScript.currentItem0Position; i >= 0; i--, panel++)
            {
                SaveScript.itemPanel[panel].SetActive(true);
                SaveScript.itemImage[panel].sprite = (Sprite)SaveScript.itemList[i];
            }
        }
        else
        {
            int panel = 0;
            for (int i = SaveScript.currentItem0Position; i > SaveScript.currentItem0Position - SaveScript.itemImage.Length; i--, panel++)
            {
                SaveScript.itemImage[panel].sprite = (Sprite)SaveScript.itemList[i];
            }

            // Checken ob der Pfeil nach oben aktiviert werden soll
            if (SaveScript.currentItem0Position < SaveScript.itemList.Count - 1)
            {
                SaveScript.inventoryArrows[0].enabled = true;
            }
            else
            {
                SaveScript.inventoryArrows[0].enabled = false;
            }

            // Checken ob der Pfeil nach unten aktiviert werden soll
            if (SaveScript.currentItem0Position >= SaveScript.itemImage.Length)
            {
                SaveScript.inventoryArrows[1].enabled = true;
            }
            else
            {
                SaveScript.inventoryArrows[1].enabled = false;
            }
        }
    }
}
