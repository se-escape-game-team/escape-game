using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowSecretLetters : MonoBehaviour
{
    [SerializeField] TextMeshPro letter;
    [SerializeField] GameObject spotPapersTrigger;

    bool triggerActive = true;
    void Update()
    {
        Debug.Log(ClickInventoryItem.SelectedItemSprite);
        if (ClickInventoryItem.SelectedItemSprite == "Erlenmeyer")
        {
            // Deaktivieren des Triggers, damit die Objekte darunter getrackt werden
            spotPapersTrigger.SetActive(false);
            triggerActive = false;

            // Tracken der anvisierten Objekte
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject))
            {
                GameObject hitGameObject = hitObject.transform.gameObject;
                Debug.Log(hitGameObject);
                if (hitGameObject.tag == "HiddenLetter")
                {
                    hitGameObject.GetComponent<TextMeshPro>().enabled = true;
                }
            }
            
        }
        // Wieder Aktivieren des Triggers falls die Tinte nicht ausgerüstet ist
        else if(!triggerActive)
        {
            spotPapersTrigger.SetActive(true);
            triggerActive = true;
        }

    }
}
