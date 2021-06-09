using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollectedGameObjects : MonoBehaviour
{
    [SerializeField] private GameObject glasses;
    void Start()
    {
        // Ueberprueft ob die Items in der Szene schon eignesammelt wurden
        GameObject[] itemsInScene = GameObject.FindGameObjectsWithTag("Selectable - Item");
        foreach (Sprite s in SaveScript.itemList)
        {
            foreach (GameObject item in itemsInScene)
            {
                if (item.GetComponent<ObjectImage>().inventoryImage.name == s.name)
                {
                    Destroy(item);
                }
            }
        }

        // Zerstoeren der Brille, falls sie schon eigesammelt wurde
        if (SaveScript.glassesCollected)
        {
            Destroy(glasses);
        }
    }
}
