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
            if (hitObject.tag == "Selectable - Item")
            {
                // Apply outline for item
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorItems;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // Adds Item to inventory (with sprite saved in ObjectImage.cs)
                    inventory.AddItem(hitObject.GetComponent<ObjectImage>().inventoryImage);
                    Destroy(hitObject);
                }
            }
            else if (hitObject.tag == "Selectable - Task")
            {
                // Apply outline for task
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    // Loads new Scene
                    ChangeScene.ChangeToTaskScene(hitObject.name);
                }
            }
            else if (hitObject.tag == "Selectable - VisionTask")
            {
                // Apply outline for task
                recentOutline = hitObject.GetComponent<Outline>();
                recentOutline.OutlineColor = colorTasks;
                recentOutline.OutlineWidth = outlineWidth;
                recentOutline.enabled = true;
                wasHit = true;

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("test");
                    Camera.main.GetComponent<SnapshotMode>().enabled = false;
                }
            }
        }

        // Reset outline
        if (!wasHit && recentOutline != null)
        {
            recentOutline.enabled = false;
            recentOutline = null;
            wasHit = false;
        }
    }
}
