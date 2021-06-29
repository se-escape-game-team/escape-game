using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Fuer beides:
 *  1) Outline Script dem GameObject hinzufuegen (QuickOutline)  !Wichtig: GameObject muss einen Collider haben!
 *  2) Outline Script deaktivieren
 *  
 * Items:
 *  3) "Selectable - Item" Tag dem GameObject hinzufuegen
 *  4) ObjectImage.cs hinzufuegen 
 *  5) Sprite fuer Inventar in ObjectImage.cs speichern
 * 
 * Tasks:
 *  3) "Selectable - Task" Tag dem GameObject hinzufuegen
 *  4) GameObject in zu oeffnende Scene umbenennen
 *  5) Scene in Build Settings hinzufuegen (File -> Build Settings)
 */

public class SelectObjects : MonoBehaviour
{
    // Farben für Outline
    [SerializeField] private Color colorItems = new Color(250, 150, 0);
    [SerializeField] private Color colorTasks = new Color(0, 250, 255);
    [SerializeField] private Color colorGlasses = new Color(0, 250, 255);

    // Hit Range
    [SerializeField] private float distance = 5f;

    [SerializeField] private int outlineWidth = 10;
    [SerializeField] private Inventory inventory;
    private Outline recentOutline;
    private bool wasHit;

    void Update()
    {
        wasHit = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, distance) && !SaveScript.pause)
        {
            GameObject hitObject = raycastHit.collider.gameObject;
            // Item
            if (hitObject.tag == "Selectable - Item" && SaveScript.glassesCollected)
            {
                // Umrandet das einsammelbare Item
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorItems;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // Fuegt dem Inventar das eingesammelte Item hinzu (ueber das in ObjectImage.cs gespeicherte Sprite)
                    inventory.AddItem(hitObject.GetComponent<ObjectImage>().inventoryImage);
                    Destroy(hitObject);
                }
            }
            // Task
            else if (hitObject.tag == "Selectable - Task" && SaveScript.glassesCollected)
            {
                // Umrandet das Objekt ueber das eine Aufgabe aufrufbar ist
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // Laed die Aufgabenszene
                    ChangeScene.ChangeToTaskScene(hitObject.name);
                }
            }
            // Task Brille
            else if (hitObject.tag == "Selectable - VisionTask")
            {
                // Gibt der Brille eine Umrandung
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorGlasses;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // Bool aktiviert, dass mit anderen selectable-Objekten (ausser der Brille) interagiert werden kann
                    SaveScript.glassesCollected = true;
                    Destroy(hitObject);
                }
            }
            // LSD-Mode
            else if (hitObject.tag == "Selectable - LightShift")
            {
                // Gibt der Brille eine Umrandung
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    SaveScript.lsdMode = true;
                }
            }
        }

        // Setzt die Umrandung des zuvor anvisierten Objekts zurueck
        if (!wasHit && recentOutline != null)
        {
            recentOutline.enabled = false;
            recentOutline = null;
            wasHit = false;
        }
    }
}