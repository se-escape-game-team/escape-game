using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabRoomLoader : MonoBehaviour
{
    [SerializeField] private GameObject glasses;
    [SerializeField] private GameObject safeDoor;
    [SerializeField] private GameObject formelAmoniakwasser;
    private Crosshair crosshair;

    void Start()
    {
        if (SaveScript.startMessageWasShown)
        {
            crosshair = GameObject.FindObjectOfType<Crosshair>();
            crosshair.CrosshairEnabled = true;
        }

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

        // Oeffnen des Safes, falls er entsperrt wurde
        if (SaveScript.safeOpen)
        {
            // Oeffnen der Tuer
            safeDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            // Entfernen des Tags, damit der Safe nicht mehr angeklickt werden kann (macht es leichter die Karte aufzunehmen)
            safeDoor.transform.parent.tag = "Untagged";
            // Deaktivieren des Colliders, damit Items im Safe angeklickt werden können
            safeDoor.transform.parent.GetComponent<BoxCollider>().enabled = false;
        }

        // Einschalten des Crosshairs, falls die Startmessage schon eingeblendet wurde
        if (SaveScript.startMessageWasShown)
        {
            GameObject.Find("Overlay").GetComponent<Crosshair>().CrosshairEnabled = true;
        }

        // Falls der Browser bereits geoeffnet wurde wird die Formel fuer die Geheimtinte angezeigt
        if (SaveScript.browserOpen)
        {
            formelAmoniakwasser.SetActive(true);
        }
    }
}
