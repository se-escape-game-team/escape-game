using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * F?r beides:
 *  1) Outline Script dem GameObject hinzuf?gen (QuickOutline)  !Wichtig: GameObject muss einen Collider haben!
 *  2) Outline Script deaktivieren
 *  
 * Items:
 *  3) "Selectable - Item" Tag dem GameObject hinzuf?gen
 *  4) ObjectImage.cs hinzuf?gen 
 *  5) Sprite f?r Inventar in ObjectImage.cs speichern
 * 
 * Tasks:
 *  3) "Selectable - Task" Tag dem GameObject hinzuf?gen
 *  4) GameObject in zu ?ffnende Scene umbenennen
 *  5) Scene in Build Settings hinzuf?gen (File -> Build Settings)
 */

public class SelectObjects : MonoBehaviour
{
    [SerializeField] private float distance = 5f;
    [SerializeField] private Color colorItems = new Color(250, 150, 0);
    [SerializeField] private Color colorTasks = new Color(0, 250, 255);
    
    [SerializeField] private int outlineWidth = 10;

    [SerializeField] private Inventory inventory;

    private Outline recentOutline;
    private bool wasHit;

    void Update()
    {
        wasHit = false;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, distance))
        {
            GameObject hitObject = raycastHit.collider.gameObject;
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
                    // F�gt dem Inventar das eingesammelte Item hinzu (�ber das in ObjectImage.cs gespeicherte Sprite)
                    inventory.AddItem(hitObject.GetComponent<ObjectImage>().inventoryImage);
                    Destroy(hitObject);
                }
            }
            else if (hitObject.tag == "Selectable - Task" && SaveScript.glassesCollected)
            {
                // Umrandet das Objekt �ber das eine Aufgabe aufrufbar ist
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // L�d die Aufgabenszene
                    ChangeScene.ChangeToTaskScene(hitObject.name);
                }
            }
            else if (hitObject.tag == "Selectable - VisionTask")
            {
                // Gibt der Brille eine Umrandung
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    Camera.main.GetComponent<SnapshotMode>().enabled = false;
                    // Bool aktiviert, dass mit anderen selectable-Objekten (au�er der Brille) interagiert werden kann
                    SaveScript.glassesCollected = true;
                    Destroy(hitObject);
                }
            }
        }

        // Setzt die Umrandung des zuvor anvisierten Objekts zur�ck
        if (!wasHit && recentOutline != null)
        {
            recentOutline.enabled = false;
            recentOutline = null;
            wasHit = false;
        }
    }
}
