using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRoomLoader : MonoBehaviour
{
    [SerializeField] private GameObject glasses;
    [SerializeField] private GameObject safeDoor;

    void Start()
    {
        // Ueberprueft ob die Items in der Szene schon eignesammelt wurden
        GameObject[] itemsInScene = GameObject.FindGameObjectsWithTag("Selectable - Item");


        //foreach (GameObject item in itemsInScene)
        //{
        //    Debug.Log(item.name);
        //}


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

        if (SaveScript.safeOpen)
        {
            // Oeffnen der Tuer
            safeDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            // Entfernen des Tags, damit der Safe nicht mehr angeklickt werden kann (macht es leichter die Karte aufzunehmen)
            safeDoor.transform.parent.tag = "Untagged";
            // Deaktivieren des Colliders, damit Items im Safe angeklickt werden können
            safeDoor.transform.parent.GetComponent<BoxCollider>().enabled = false;
        }

        if (SaveScript.startMessageWasShown)
        {
            GameObject.Find("Overlay").GetComponent<Crosshair>().CrosshairEnabled = true;
        }
    }
}
